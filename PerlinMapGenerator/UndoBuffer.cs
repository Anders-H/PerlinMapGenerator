#nullable enable
using System.Collections.Generic;

namespace PerlinMapGenerator;

public class UndoBuffer
{
    // _pointer always refers to the current state in _stack.
    // Undo moves it backward (toward index 0), redo moves it forward.
    private int _pointer;
    private readonly List<Document> _stack;

    public bool CanUndo => _pointer > 0;
    public bool CanRedo => _pointer < _stack.Count - 1;

    public UndoBuffer()
    {
        _pointer = -1;
        _stack = [];
    }

    /// <summary>
    /// Saves a snapshot of the current state. Any redo history beyond
    /// the current position is discarded.
    /// </summary>
    public void PushState(Document state)
    {
        // Discard all redo states ahead of the current pointer.
        if (_pointer < _stack.Count - 1)
            _stack.RemoveRange(_pointer + 1, _stack.Count - _pointer - 1);

        var newState = new Document();
        newState.Set(state);
        _stack.Add(newState);
        _pointer = _stack.Count - 1;
    }

    /// <summary>
    /// Steps one state backward and returns a copy of that state,
    /// or null if there is nothing to undo.
    /// </summary>
    public Document? DoUndo()
    {
        if (!CanUndo)
            return null;

        _pointer--;
        var newState = new Document();
        newState.Set(_stack[_pointer]);
        return newState;
    }

    /// <summary>
    /// Steps one state forward and returns a copy of that state,
    /// or null if there is nothing to redo.
    /// </summary>
    public Document? DoRedo()
    {
        if (!CanRedo)
            return null;

        _pointer++;
        var newState = new Document();
        newState.Set(_stack[_pointer]);
        return newState;
    }
}
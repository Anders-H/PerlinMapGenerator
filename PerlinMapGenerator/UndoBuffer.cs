#nullable enable
using System.Collections.Generic;

namespace PerlinMapGenerator;

public class UndoBuffer
{
    private int _undoPointer;
    private readonly List<Document> _undoStack;

    public UndoBuffer()
    {
        _undoPointer = -1;
        _undoStack = [];
    }

    public Document? DoUndo()
    {
        if (_undoStack.Count <= 0)
            return null;

        var nextIndex = _undoPointer + 1;

        if (nextIndex >= _undoStack.Count)
            return null;

        _undoPointer = nextIndex;
        var result = new Document();
        result.Set(_undoStack[_undoPointer]);
        return result;
    }

    public Document? DoRedo()
    {
        if (_undoStack.Count <= 0)
            return null;

        var previousIndex = _undoPointer - 1;

        if (previousIndex < 0)
            return null;

        _undoPointer = previousIndex;
        var result = new Document();
        result.Set(_undoStack[_undoPointer]);
        return result;

    }

    public void PushState(Document state)
    {
        while (_undoPointer < _undoStack.Count - 1)
            _undoStack.RemoveAt(_undoStack.Count - 1);

        _undoStack.Add(state);
        _undoPointer = _undoStack.Count - 2;
    }
}
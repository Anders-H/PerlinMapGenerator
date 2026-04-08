#nullable enable
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PerlinMapGenerator.Dialogs.ColorDialogs;

namespace PerlinMapGenerator.Dialogs;

public partial class ColorsDialog : Form
{
    private ColorLayerList ColorLayers { get; }
    public Document? Document { get; set; }
    public Action? ApplyDelegate { get; set; }

    public ColorsDialog()
    {
        ColorLayers = [];
        InitializeComponent();
    }

    private void ColorsDialog_Load(object sender, EventArgs e)
    {
        if (Document == null || ApplyDelegate == null)
            throw new SystemException();

        Document.SortColorLayers();

        foreach (var existingColorLayer in Document.ColorLayers)
            ColorLayers.Add(new ColorLayer(existingColorLayer));
    }

    private void ColorsDialog_Shown(object sender, EventArgs e)
    {
        listView1.Items.Clear();
        listView1.Columns.Clear();
        listView1.Columns.Add("Name", 150);
        listView1.Columns.Add("<= Position", 150, HorizontalAlignment.Center);
        Refresh();
        RebuildForm();
        pictureBox1.Invalidate();
    }

    private void RebuildForm()
    {
        listView1.BeginUpdate();
        listView1.Items.Clear();
        
        foreach (var colorLayer in ColorLayers)
        {
            var li = new ListViewItem(colorLayer.Name);
            li.SubItems.Add(colorLayer.HighestValue.ToString("n0"));
            li.Tag = colorLayer;
            listView1.Items.Add(li);

            var isDark = colorLayer.Color.GetBrightness() < 0.5f;
            li.ForeColor = isDark ? Color.White : Color.Black;
            li.BackColor = colorLayer.Color;
        }

        listView1.EndUpdate();
        pictureBox1.Invalidate();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (Document == null)
            throw new SystemException();

        using var x = new AddColorDialog();
        
        if (x.ShowDialog(this) != DialogResult.OK)
            return;

        if (x.NewColorLayer == null)
            throw new SystemException();

        ColorLayers.Add(x.NewColorLayer);
        ColorLayers.SortColorLayers();
        RebuildForm();
        FindColorLayer(x.NewColorLayer);
        pictureBox1.Invalidate();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count <= 0)
        {
            MessageBox.Show(this, @"Please select a color layer to edit.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var x = new EditColorDialog();
        x.ColorLayer = (ColorLayer)listView1.SelectedItems[0].Tag;
        x.ShowDialog(this);
        RebuildForm();
        FindColorLayer(x.ColorLayer);
        pictureBox1.Invalidate();
    }

    private void FindColorLayer(ColorLayer? colorLayer)
    {
        if (colorLayer == null)
            return;

        foreach (ListViewItem item in listView1.Items)
        {
            var otherLayer = item.Tag as ColorLayer;

            if (otherLayer != null)
                continue;

            if (otherLayer != colorLayer)
                continue;

            listView1.SelectedItems.Clear();
            item.Selected = true;
            item.Focused = true;
            item.EnsureVisible();
            return;
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count <= 0)
        {
            MessageBox.Show(this, @"Please select a color layer to delete.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (listView1.SelectedItems[0].Tag is not ColorLayer colorLayer)
            return;

        if (MessageBox.Show(this, $@"Are you sure you want to delete the selected color layer ({colorLayer})?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        ColorLayers.Remove(colorLayer);
        RebuildForm();
        pictureBox1.Invalidate();
    }

    private void btnApply_Click(object sender, EventArgs e)
    {
        RebuildColorLayers();
        ApplyDelegate?.Invoke();

        if (ColorLayers.Count < 2)
            MessageBox.Show(this, @"You must have at least 2 colors registered.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        RebuildColorLayers();
        ApplyDelegate?.Invoke();

        if (ColorLayers.Count < 2)
        {
            MessageBox.Show(this, @"You must have at least 2 colors registered.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DialogResult = DialogResult.OK;
    }

    private void RebuildColorLayers()
    {
        if (Document == null)
            throw new SystemException();

        var newColors = ColorLayers.OrderBy(x => x.HighestValue).ToList();
        Document.ColorLayers.Clear();

        foreach (var colorLayer in newColors)
            Document.ColorLayers.Add(new ColorLayer(colorLayer));
    }

    private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        var li = listView1.GetItemAt(e.X, e.Y);

        if (li == null)
            return;

        listView1.SelectedItems.Clear();
        li.Selected = true;
        btnEdit_Click(sender, e);
    }

    private void listView1_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Enter:
                btnEdit_Click(sender, e);
                break;
            case Keys.Delete:
                btnDelete_Click(sender, e);
                break;
        }
    }

    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        var x = 0;

        for (var i = 0; i < 100; i++)
        {
            var color = ColorLayers.GetColorForIntValue(i);
            using var brush = new SolidBrush(color);
            e.Graphics.FillRectangle(brush, x, 0, 4, pictureBox1.ClientRectangle.Height);
            x += 4;
        }
        
        e.Graphics.DrawRectangle(Pens.DimGray, 0, 0, pictureBox1.ClientRectangle.Width - 1, pictureBox1.ClientRectangle.Height - 1);
        e.Graphics.DrawRectangle(Pens.White, 1, 1, pictureBox1.ClientRectangle.Width - 3, pictureBox1.ClientRectangle.Height - 3);
    }
}
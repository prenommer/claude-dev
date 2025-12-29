<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UniversalViewerForm
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NouveauToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OuvrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÉditionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutilsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WordwrapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UppercaseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LowercaseToolStripMenuItem1 = New System.Windows.Forms.ToolStripTextBox()
        Me.CapitalizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NettoyerSupprimerLesLignesVidesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveEmptyLinesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ZoomInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomResetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ColorizeJSONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeautifierJSONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MinifierJSONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewerBox = New System.Windows.Forms.RichTextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichierToolStripMenuItem, Me.ÉditionToolStripMenuItem, Me.OutilsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NouveauToolStripMenuItem, Me.OuvrirToolStripMenuItem, Me.ToolStripSeparator1, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ToolStripSeparator2, Me.QuitToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        Me.FichierToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.FichierToolStripMenuItem.Text = "Fichier"
        '
        'NouveauToolStripMenuItem
        '
        Me.NouveauToolStripMenuItem.Name = "NouveauToolStripMenuItem"
        Me.NouveauToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NouveauToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.NouveauToolStripMenuItem.Text = "Nouveau"
        '
        'OuvrirToolStripMenuItem
        '
        Me.OuvrirToolStripMenuItem.Name = "OuvrirToolStripMenuItem"
        Me.OuvrirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OuvrirToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.OuvrirToolStripMenuItem.Text = "Ouvrir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(222, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.SaveToolStripMenuItem.Text = "Enregistrer"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.SaveAsToolStripMenuItem.Text = "Enregistrer sous"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(222, 6)
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.QuitToolStripMenuItem.Text = "Quitter"
        '
        'ÉditionToolStripMenuItem
        '
        Me.ÉditionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.RedoToolStripMenuItem, Me.ToolStripSeparator3, Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripSeparator4, Me.SelectAllToolStripMenuItem})
        Me.ÉditionToolStripMenuItem.Name = "ÉditionToolStripMenuItem"
        Me.ÉditionToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.ÉditionToolStripMenuItem.Text = "Édition"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.UndoToolStripMenuItem.Text = "Annuler"
        '
        'RedoToolStripMenuItem
        '
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        Me.RedoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.RedoToolStripMenuItem.Text = "Rétablir"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(204, 6)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.CutToolStripMenuItem.Text = "Couper"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.CopyToolStripMenuItem.Text = "Copier"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.PasteToolStripMenuItem.Text = "Coller"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.DeleteToolStripMenuItem.Text = "Supprimer"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(204, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.SelectAllToolStripMenuItem.Text = "Tout sélectionner"
        '
        'OutilsToolStripMenuItem
        '
        Me.OutilsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WordwrapToolStripMenuItem, Me.FontToolStripMenuItem, Me.TextColorToolStripMenuItem, Me.BackColorToolStripMenuItem, Me.StatsToolStripMenuItem, Me.ToolStripMenuItem, Me.CapitalizeToolStripMenuItem, Me.NettoyerSupprimerLesLignesVidesToolStripMenuItem, Me.ToolStripSeparator5, Me.ZoomInToolStripMenuItem, Me.ZoomOutToolStripMenuItem, Me.ZoomResetToolStripMenuItem, Me.ToolStripSeparator6, Me.ColorizeJSONToolStripMenuItem, Me.BeautifierJSONToolStripMenuItem, Me.MinifierJSONToolStripMenuItem})
        Me.OutilsToolStripMenuItem.Name = "OutilsToolStripMenuItem"
        Me.OutilsToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.OutilsToolStripMenuItem.Text = "Outils"
        '
        'WordwrapToolStripMenuItem
        '
        Me.WordwrapToolStripMenuItem.Name = "WordwrapToolStripMenuItem"
        Me.WordwrapToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.WordwrapToolStripMenuItem.Text = "Retour à la ligne automatique"
        '
        'FontToolStripMenuItem
        '
        Me.FontToolStripMenuItem.Name = "FontToolStripMenuItem"
        Me.FontToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.FontToolStripMenuItem.Text = "Police"
        '
        'TextColorToolStripMenuItem
        '
        Me.TextColorToolStripMenuItem.Name = "TextColorToolStripMenuItem"
        Me.TextColorToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.TextColorToolStripMenuItem.Text = "Couleur du texte…"
        '
        'BackColorToolStripMenuItem
        '
        Me.BackColorToolStripMenuItem.Name = "BackColorToolStripMenuItem"
        Me.BackColorToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.BackColorToolStripMenuItem.Text = "Couleur du fond…"
        '
        'StatsToolStripMenuItem
        '
        Me.StatsToolStripMenuItem.Name = "StatsToolStripMenuItem"
        Me.StatsToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.StatsToolStripMenuItem.Text = "Statistiques"
        '
        'ToolStripMenuItem
        '
        Me.ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UppercaseToolStripMenuItem1, Me.LowercaseToolStripMenuItem1})
        Me.ToolStripMenuItem.Name = "ToolStripMenuItem"
        Me.ToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ToolStripMenuItem.Text = "Convertir Majuscules"
        '
        'UppercaseToolStripMenuItem1
        '
        Me.UppercaseToolStripMenuItem1.Name = "UppercaseToolStripMenuItem1"
        Me.UppercaseToolStripMenuItem1.Size = New System.Drawing.Size(246, 22)
        Me.UppercaseToolStripMenuItem1.Text = "Convertir Majuscules"
        '
        'LowercaseToolStripMenuItem1
        '
        Me.LowercaseToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LowercaseToolStripMenuItem1.Name = "LowercaseToolStripMenuItem1"
        Me.LowercaseToolStripMenuItem1.Size = New System.Drawing.Size(186, 23)
        Me.LowercaseToolStripMenuItem1.Text = "Convertir Minuscules"
        '
        'CapitalizeToolStripMenuItem
        '
        Me.CapitalizeToolStripMenuItem.Name = "CapitalizeToolStripMenuItem"
        Me.CapitalizeToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.CapitalizeToolStripMenuItem.Text = "Capitaliser"
        '
        'NettoyerSupprimerLesLignesVidesToolStripMenuItem
        '
        Me.NettoyerSupprimerLesLignesVidesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveEmptyLinesToolStripMenuItem})
        Me.NettoyerSupprimerLesLignesVidesToolStripMenuItem.Name = "NettoyerSupprimerLesLignesVidesToolStripMenuItem"
        Me.NettoyerSupprimerLesLignesVidesToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.NettoyerSupprimerLesLignesVidesToolStripMenuItem.Text = "Nettoyer"
        '
        'RemoveEmptyLinesToolStripMenuItem
        '
        Me.RemoveEmptyLinesToolStripMenuItem.Name = "RemoveEmptyLinesToolStripMenuItem"
        Me.RemoveEmptyLinesToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.RemoveEmptyLinesToolStripMenuItem.Text = "Supprimer les lignes vides"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(227, 6)
        '
        'ZoomInToolStripMenuItem
        '
        Me.ZoomInToolStripMenuItem.Name = "ZoomInToolStripMenuItem"
        Me.ZoomInToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ZoomInToolStripMenuItem.Text = "Zoom +"
        '
        'ZoomOutToolStripMenuItem
        '
        Me.ZoomOutToolStripMenuItem.Name = "ZoomOutToolStripMenuItem"
        Me.ZoomOutToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ZoomOutToolStripMenuItem.Text = "Zoom –"
        '
        'ZoomResetToolStripMenuItem
        '
        Me.ZoomResetToolStripMenuItem.Name = "ZoomResetToolStripMenuItem"
        Me.ZoomResetToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ZoomResetToolStripMenuItem.Text = "Zoom 100%"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(227, 6)
        '
        'ColorizeJSONToolStripMenuItem
        '
        Me.ColorizeJSONToolStripMenuItem.Name = "ColorizeJSONToolStripMenuItem"
        Me.ColorizeJSONToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ColorizeJSONToolStripMenuItem.Text = "Coloriser JSON"
        '
        'BeautifierJSONToolStripMenuItem
        '
        Me.BeautifierJSONToolStripMenuItem.Name = "BeautifierJSONToolStripMenuItem"
        Me.BeautifierJSONToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BeautifierJSONToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.BeautifierJSONToolStripMenuItem.Text = "Beautifier JSON"
        '
        'MinifierJSONToolStripMenuItem
        '
        Me.MinifierJSONToolStripMenuItem.Name = "MinifierJSONToolStripMenuItem"
        Me.MinifierJSONToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.MinifierJSONToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.MinifierJSONToolStripMenuItem.Text = "Minifier JSON"
        '
        'ViewerBox
        '
        Me.ViewerBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewerBox.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.ViewerBox.HideSelection = False
        Me.ViewerBox.Location = New System.Drawing.Point(0, 24)
        Me.ViewerBox.Name = "ViewerBox"
        Me.ViewerBox.Size = New System.Drawing.Size(800, 426)
        Me.ViewerBox.TabIndex = 1
        Me.ViewerBox.Text = ""
        '
        'UniversalViewerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ViewerBox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "UniversalViewerForm"
        Me.Text = "Universal Viewer"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ViewerBox As RichTextBox
    Friend WithEvents FichierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ÉditionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OutilsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OuvrirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NouveauToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents QuitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WordwrapToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FontToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TextColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CapitalizeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NettoyerSupprimerLesLignesVidesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ZoomInToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ZoomOutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ZoomResetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents UppercaseToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RemoveEmptyLinesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LowercaseToolStripMenuItem1 As ToolStripTextBox
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ColorizeJSONToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BeautifierJSONToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MinifierJSONToolStripMenuItem As ToolStripMenuItem
End Class
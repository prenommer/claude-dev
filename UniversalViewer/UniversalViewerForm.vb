Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
Imports Newtonsoft.Json.Linq

    Public Class UniversalViewerForm
        Inherits Form

        Private CurrentFilePath As String = Nothing
        Private IsDirty As Boolean = False

        ' Met à jour le titre de la fenêtre
        Private Sub UpdateWindowTitle()
        Dim fileName As String = If(CurrentFilePath Is Nothing, "Nouveau document", Path.GetFileName(CurrentFilePath))
        Dim dirtyMark As String = If(IsDirty, "*", "")
        Text = $"{fileName}{dirtyMark} - Universal Viewer"
    End Sub

    ' -------------------------------
    '  ENREGISTRER
    ' -------------------------------

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If CurrentFilePath Is Nothing Then
            SaveAsToolStripMenuItem_Click(sender, e)
        Else
            SaveToFile(CurrentFilePath)
        End If
    End Sub

    ' Fonction de sauvegarde réelle
    Private Sub SaveToFile(path As String)
        File.WriteAllText(path, ViewerBox.Text)
        IsDirty = False
        UpdateWindowTitle()
    End Sub


    Private Sub MenuSaveAs(path As String)
        File.WriteAllText(path, ViewerBox.Text)
        IsDirty = False
        UpdateWindowTitle()
    End Sub

    ' -------------------------------
    '  ENREGISTRER SOUS
    ' -------------------------------

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim telechargements As String = Path.Combine(System.Windows.Forms.Application.StartupPath, "Téléchargements")
        If Not Directory.Exists(telechargements) Then Directory.CreateDirectory(telechargements)

        Using dlg As New SaveFileDialog()
            dlg.Filter = "Fichiers texte|*.txt|JSON|*.json|XML|*.xml|Tous les fichiers|*.*"
            dlg.Title = "Enregistrer sous…"
            dlg.InitialDirectory = telechargements

            If dlg.ShowDialog() = DialogResult.OK Then
                CurrentFilePath = dlg.FileName
                SaveToFile(CurrentFilePath)
            End If
        End Using
    End Sub


    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        If ConfirmSaveIfDirty() Then
            Close()
        End If
    End Sub

    Private Sub ViewerBox_TextChanged(sender As Object, e As EventArgs) Handles ViewerBox.TextChanged
        If Not IsDirty Then
            IsDirty = True
            UpdateWindowTitle()
        End If
    End Sub

    Private Function ConfirmSaveIfDirty() As Boolean
        If Not IsDirty Then Return True

        Dim result = MessageBox.Show(
        "Le document a été modifié. Voulez-vous enregistrer les changements ?",
        "Universal Viewer",
        MessageBoxButtons.YesNoCancel,
        MessageBoxIcon.Warning
    )

        Select Case result
            Case DialogResult.Yes
                SaveToolStripMenuItem_Click(Nothing, Nothing)
                Return Not IsDirty ' si l’enregistrement a réussi
            Case DialogResult.No
                Return True
            Case DialogResult.Cancel
                Return False
            Case Else

        End Select

        Return True
    End Function

    Private Sub NouveauToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NouveauToolStripMenuItem.Click
        If Not ConfirmSaveIfDirty() Then Exit Sub

        ViewerBox.Clear()
        CurrentFilePath = Nothing
        IsDirty = False
        UpdateWindowTitle()
    End Sub


    ' -------------------------------
    '  OUVRIR
    ' -------------------------------

    Private Sub OuvrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OuvrirToolStripMenuItem.Click
        If Not ConfirmSaveIfDirty() Then Exit Sub

        Dim telechargements As String = Path.Combine(System.Windows.Forms.Application.StartupPath, "Téléchargements")
        If Not Directory.Exists(telechargements) Then Directory.CreateDirectory(telechargements)

        Using dlg As New OpenFileDialog()
            dlg.Filter = "Fichiers texte|*.txt|JSON|*.json|XML|*.xml|Tous les fichiers|*.*"
            dlg.Title = "Ouvrir un fichier"
            dlg.InitialDirectory = telechargements

            If dlg.ShowDialog() = DialogResult.OK Then
                CurrentFilePath = dlg.FileName
                ViewerBox.Text = File.ReadAllText(CurrentFilePath)
                IsDirty = False
                UpdateWindowTitle()
            End If
        End Using
    End Sub

    ' ANNULER
    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        If ViewerBox.CanUndo Then ViewerBox.Undo()
    End Sub

    ' RÉTABLIR
    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        If ViewerBox.CanRedo Then ViewerBox.Redo()
    End Sub

    ' COUPER
    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        ViewerBox.Cut()
    End Sub

    ' COPIER
    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        ViewerBox.Copy()
    End Sub

    ' COLLER
    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        ViewerBox.Paste()
    End Sub

    ' SUPPRIMER
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        ViewerBox.SelectedText = ""
    End Sub

    ' TOUT SÉLECTIONNER
    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        ViewerBox.SelectAll()
    End Sub

    Private Sub WordWrapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WordWrapToolStripMenuItem.Click
        ViewerBox.WordWrap = Not ViewerBox.WordWrap
        WordWrapToolStripMenuItem.Checked = ViewerBox.WordWrap
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        Using dlg As New FontDialog()
            dlg.Font = ViewerBox.Font
            If dlg.ShowDialog() = DialogResult.OK Then
                ViewerBox.Font = dlg.Font
            End If
        End Using
    End Sub

    Private Sub TextColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TextColorToolStripMenuItem.Click
        Using dlg As New ColorDialog()
            dlg.Color = ViewerBox.ForeColor
            If dlg.ShowDialog() = DialogResult.OK Then
                ViewerBox.ForeColor = dlg.Color
            End If
        End Using
    End Sub

    Private Sub BackColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackColorToolStripMenuItem.Click
        Using dlg As New ColorDialog()
            dlg.Color = ViewerBox.BackColor
            If dlg.ShowDialog() = DialogResult.OK Then
                ViewerBox.BackColor = dlg.Color
            End If
        End Using
    End Sub

    Private Sub StatsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatsToolStripMenuItem.Click
        Dim text = ViewerBox.Text
        Dim lines = ViewerBox.Lines.Length
        Dim chars = text.Length
        Dim words = text.Split({" "c, vbCrLf}, StringSplitOptions.RemoveEmptyEntries).Length

        MessageBox.Show(
        $"Lignes : {lines}{vbCrLf}Mots : {words}{vbCrLf}Caractères : {chars}",
        "Statistiques du document",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information
    )
    End Sub

    Private Sub UppercaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UppercaseToolStripMenuItem1.Click
        ViewerBox.SelectedText = ViewerBox.SelectedText.ToUpper()
    End Sub

    Private Sub LowercaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LowercaseToolStripMenuItem1.Click
        ViewerBox.SelectedText = ViewerBox.SelectedText.ToLower()
    End Sub

    Private Sub CapitalizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CapitalizeToolStripMenuItem.Click
        Dim txt = ViewerBox.SelectedText.ToLower()
        Dim result = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txt)
        ViewerBox.SelectedText = result
    End Sub

    Private Sub RemoveEmptyLinesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveEmptyLinesToolStripMenuItem.Click
        Dim lines = ViewerBox.Lines.Where(Function(l) l.Trim() <> "").ToArray()
        ViewerBox.Lines = lines
    End Sub

    Private Sub ZoomInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomInToolStripMenuItem.Click
        If ViewerBox.ZoomFactor < 5.0F Then
            ViewerBox.ZoomFactor += 0.1F
        End If
    End Sub

    Private Sub ZoomOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomOutToolStripMenuItem.Click
        If ViewerBox.ZoomFactor > 0.2F Then
            ViewerBox.ZoomFactor -= 0.1F
        End If
    End Sub

    Private Sub ZoomResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomResetToolStripMenuItem.Click
        ViewerBox.ZoomFactor = 1.0F
    End Sub

    Private Sub ColorizeJSON()

        ' --- Réinitialisation complète ---
        ViewerBox.SelectAll()
        ViewerBox.SelectionColor = Color.Black
        ViewerBox.SelectionFont = ViewerBox.Font
        ViewerBox.Select(0, 0)

        ' --- 1. Clés JSON : "clé":
        ApplyColor(New Regex("""([^""]+)""(?=\s*:)"), Color.RoyalBlue)

        ' --- 2. Chaînes (valeurs) : "valeur" (multilignes)
        ApplyColor(New Regex(":\s*""(.*?)""", RegexOptions.Singleline), Color.Red)

        ' --- 2b. URLs dans les valeurs JSON ---
        ApplyColor(New Regex("https?://[^\s""']+"), Color.Blue)

        ' --- Soulignement des URLs ---
        Dim urlRegex As New Regex("https?://[^\s""']+")
        For Each m As Match In urlRegex.Matches(ViewerBox.Text)
            ViewerBox.Select(m.Index, m.Length)
            ViewerBox.SelectionColor = Color.Blue
            ViewerBox.SelectionFont = New System.Drawing.Font(ViewerBox.Font, FontStyle.Underline)
        Next

        ' --- 3. Nombres
        ApplyColor(New Regex("(?<=:\s*)(-?\d+(\.\d+)?)(?=[,\}\]

])"), Color.DarkGreen)

        ' --- 4. Booléens et null
        ApplyColor(New Regex("(?<=:\s*)(true|false|null)(?=[,\}\]

])"), Color.Purple)

        ' --- 5. Accolades et crochets
        ApplyColor(New Regex("[\{\}

\[\]

]"), Color.DimGray)

        ' --- 6. Deux-points et virgules
        ApplyColor(New Regex("[:,]"), Color.Gray)

        ViewerBox.Select(0, 0)

    End Sub

    Private Sub ApplyColor(r As Regex, c As Color)
        For Each m As Match In r.Matches(ViewerBox.Text)
            ViewerBox.Select(m.Index, m.Length)
            ViewerBox.SelectionColor = c
        Next
    End Sub

    Private Sub ApplyColor(pattern As Regex, c As Color, options As RegexOptions)
        Dim r As New Regex(pattern.ToString(), options)
        ApplyColor(r, c)
    End Sub

    Private Sub ColorizeJSONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorizeJSONToolStripMenuItem.Click
        ColorizeJSON()
    End Sub

    Private Sub Colorize()
        Dim selStart As Integer = ViewerBox.SelectionStart
        Dim selLength As Integer = ViewerBox.SelectionLength

        ViewerBox.SuspendLayout()
        RemoveHandler ViewerBox.TextChanged, AddressOf ViewerBox_TextChanged

        Dim txt As String = ViewerBox.Text

        ' Réinitialisation
        ViewerBox.SelectAll()
        ViewerBox.SelectionColor = Color.Black

        Select Case DetectFormat(txt)

            Case "ini"
                ColorizeINI()

            Case "markdown"
                ColorizeMarkdown()

            Case "log"
                ColorizeLOG()

            Case "yaml"
                ColorizeYAML()

            Case "sql"
                ColorizeSQL()

            Case "html"
                ColorizeHTML()

            Case Else
                ' Texte brut : ne rien faire
        End Select

        ViewerBox.SelectionStart = selStart
        ViewerBox.SelectionLength = selLength

        AddHandler ViewerBox.TextChanged, AddressOf ViewerBox_TextChanged
        ViewerBox.ResumeLayout()
    End Sub

    Private Function DetectFormat(txt As String) As String
        Dim t = txt.TrimStart()

        ' --- INI ---
        If t.StartsWith("[") AndAlso t.Contains("]") AndAlso t.Contains("=") Then
            Return "ini"
        End If

        ' --- Markdown ---
        If t.StartsWith("#") OrElse t.StartsWith("```") Then
            Return "markdown"
        End If

        ' --- LOG ---
        If Regex.IsMatch(t, "^\d{4}-\d{2}-\d{2}") Then
            Return "log"
        End If

        ' --- YAML ---
        If t.Contains(": ") AndAlso Not t.Contains("=") Then
            Return "yaml"
        End If

        ' --- SQL ---
        If Regex.IsMatch(t.ToUpper(), "^(SELECT|INSERT|UPDATE|DELETE|CREATE|DROP|ALTER)\b") Then
            Return "sql"
        End If

        ' --- HTML ---
        If t.StartsWith("<") AndAlso t.Contains(">") Then
            Return "html"
        End If

        Return "text"
    End Function

    Private Sub ColorizeXML()
        Dim txt = ViewerBox.Text

        ' Balises <tag> ou </tag>
        ApplyColor(New Regex("</?[^>]+>"), Color.RoyalBlue)

        ' Attributs name=
        ApplyColor(New Regex("\b\w+(?=\=)"), Color.Purple)

        ' Valeurs d'attributs "value"
        ApplyColor(New Regex("""[^""]*"""), Color.Brown)

        ' Entités &amp; &lt; etc.
        ApplyColor(New Regex("&\w+;"), Color.DarkGreen)

        ' Commentaires <!-- ... -->
        ApplyColor(New Regex("<!--[\s\S]*?-->"), Color.Gray)
    End Sub

    Private Sub ColorizeINI()
        Dim txt = ViewerBox.Text

        ' Sections [Section]
        ApplyColor(New Regex("^\s*

\[[^\]

]+\]

", RegexOptions.Multiline), Color.RoyalBlue)

        ' Commentaires ; ou #
        ApplyColor(New Regex("[;#].*$", RegexOptions.Multiline), Color.DarkGreen)

        ' Clés avant le =
        ApplyColor(New Regex("^\s*[\w\.-]+(?=\s*=)", RegexOptions.Multiline), Color.Purple)

        ' Valeurs entre guillemets
        ApplyColor(New Regex("""[^""]*"""), Color.Brown)

        ' Symbole =
        ApplyColor(New Regex("="), Color.Gray)
    End Sub

    Private Sub ColorizeMarkdown()
        Dim txt = ViewerBox.Text

        ' Titres #, ##, ###...
        ApplyColor(New Regex("^(#{1,6})\s.*$", RegexOptions.Multiline), Color.RoyalBlue)

        ' Citations >
        ApplyColor(New Regex("^\s*>\s.*$", RegexOptions.Multiline), Color.DimGray)

        ' Listes - item / * item / + item
        ApplyColor(New Regex("^\s*[-\*\+]\s+.*$", RegexOptions.Multiline), Color.DarkGreen)

        ' Listes numérotées 1. item
        ApplyColor(New Regex("^\s*\d+\.\s+.*$", RegexOptions.Multiline), Color.DarkGreen)

        ' Gras **texte**
        ApplyColor(New Regex("\*\*(.*?)\*\*"), Color.Purple)

        ' Italique *texte*
        ApplyColor(New Regex("(?<!\*)\*(?!\*)(.*?)\*(?<!\*)"), Color.MediumPurple)

        ' Code inline `code`
        ApplyColor(New Regex("`[^`]*`"), Color.Brown)

        ' Blocs de code ``` ... ```
        ApplyColor(New Regex("```[\s\S]*?```"), Color.Gray)

        ' Liens [texte](url)
        ApplyColor(New Regex("

\[[^\]

]+\]

\([^\)]+\)"), Color.SaddleBrown)
    End Sub

    Private Sub ColorizeLOG()
        Dim txt = ViewerBox.Text

        ' Timestamps : 2025-12-26 17:34:12
        ApplyColor(New Regex("\b\d{4}-\d{2}-\d{2}[ T]\d{2}:\d{2}:\d{2}\b"), Color.RoyalBlue)

        ' Niveaux de log
        ApplyColor(New Regex("\bINFO\b"), Color.DarkGreen)
        ApplyColor(New Regex("\bDEBUG\b"), Color.Gray)
        ApplyColor(New Regex("\bWARN(ING)?\b"), Color.Orange)
        ApplyColor(New Regex("\bERROR\b"), Color.Red)
        ApplyColor(New Regex("\bFATAL\b"), Color.DarkRed)

        ' Chemins Windows C:\...
        ApplyColor(New Regex("[A-Z]:\

\[^\s]+"), Color.SaddleBrown)

        ' Chemins Linux /usr/bin/...
        ApplyColor(New Regex("/[^\s]+"), Color.SaddleBrown)

        ' Exceptions
        ApplyColor(New Regex("\b\w+Exception\b"), Color.Red)

        ' Stacktrace : at Namespace.Class.Method()
        ApplyColor(New Regex("^\s*at\s+.*$", RegexOptions.Multiline), Color.DimGray)

        ' IP + port
        ApplyColor(New Regex("\b\d{1,3}(\.\d{1,3}){3}(:\d+)?\b"), Color.MediumPurple)
    End Sub

    Private Sub ColorizeYAML()
        Dim txt = ViewerBox.Text

        ' Clés : clé:
        ApplyColor(New Regex("^\s*[\w\-]+\s*(?=:)"), Color.RoyalBlue, RegexOptions.Multiline)

        ' Deux-points :
        ApplyColor(New Regex(":"), Color.Gray)

        ' Listes : - élément
        ApplyColor(New Regex("^\s*-\s+.*$", RegexOptions.Multiline), Color.DarkGreen)

        ' Chaînes entre guillemets simples ou doubles
        ApplyColor(New Regex("""[^""]*"""), Color.Brown)
        ApplyColor(New Regex("'[^']*'"), Color.Brown)

        ' Booléens et null
        ApplyColor(New Regex("\b(true|false|null)\b"), Color.Purple)

        ' Commentaires #
        ApplyColor(New Regex("#.*$"), Color.DimGray, RegexOptions.Multiline)
    End Sub

    Private Sub ColorizeSQL()
        Dim txt = ViewerBox.Text

        ' Mots-clés SQL (majuscules ou minuscules)
        Dim keywords As String = "\b(SELECT|FROM|WHERE|INSERT|INTO|VALUES|UPDATE|SET|DELETE|JOIN|LEFT|RIGHT|INNER|OUTER|ON|GROUP BY|ORDER BY|HAVING|LIMIT|OFFSET|AS|DISTINCT|AND|OR|NOT|IN|IS|NULL|LIKE|BETWEEN|CREATE|TABLE|PRIMARY KEY|FOREIGN KEY|DROP|ALTER|ADD)\b"
        ApplyColor(New Regex(keywords, RegexOptions.IgnoreCase), System.Drawing.Color.RoyalBlue)

        ' Fonctions SQL (COUNT, SUM, AVG, MIN, MAX…)
        ApplyColor(New Regex("\b(COUNT|SUM|AVG|MIN|MAX|NOW|UPPER|LOWER|ROUND)\s*\(", RegexOptions.IgnoreCase), System.Drawing.Color.MediumBlue)

        ' Chaînes 'texte' ou "texte"
        ApplyColor(New Regex("'[^']*'"), System.Drawing.Color.Brown)
        ApplyColor(New Regex("""[^""]*"""), System.Drawing.Color.Brown)

        ' Nombres
        ApplyColor(New Regex("\b\d+(\.\d+)?\b"), System.Drawing.Color.DarkGreen)

        ' Opérateurs
        ApplyColor(New Regex("=|<>|!=|<=|>=|\+|\-|\*|/"), System.Drawing.Color.Purple)

        ' Commentaires -- ...
        ApplyColor(New Regex("--.*$", RegexOptions.Multiline), System.Drawing.Color.DimGray)

        ' Commentaires /* ... */
        ApplyColor(New Regex("/\*[\s\S]*?\*/"), System.Drawing.Color.Gray)
    End Sub

    'Private Sub ColorizeCSV()
    '   Dim txt = ViewerBox.Text

    '  ' Séparateurs ; ou ,
    ' ApplyColor(New Regex("[;,]"), System.Drawing.Color.Gray)

    '' Valeurs entre guillemets "..."
    'ApplyColor(New Regex("""[^""]*"""), System.Drawing.Color.Brown)

    '' Nombres (entiers ou décimaux)
    'ApplyColor(New Regex("\b\d+(\.\d+)?\b"), System.Drawing.Color.DarkGreen)

    '' Première ligne = en-têtes (ligne 1 entière)
    'ApplyColor(New Regex("^[^\r\n]+$", RegexOptions.Multiline), System.Drawing.Color.RoyalBlue)
    'End Sub

    Private Sub ColorizeHTML()
        Dim txt = ViewerBox.Text

        ' Commentaires <!-- ... -->
        ApplyColor(New Regex("<!--[\s\S]*?-->"), System.Drawing.Color.DimGray)

        ' Balises ouvrantes <tag ...>
        ApplyColor(New Regex("<\s*\w+[^>]*>"), System.Drawing.Color.RoyalBlue)

        ' Balises fermantes </tag>
        ApplyColor(New Regex("</\s*\w+\s*>"), System.Drawing.Color.MediumBlue)

        ' Attributs name=
        ApplyColor(New Regex("\b\w+(?=\=)"), System.Drawing.Color.Purple)

        ' Valeurs d'attributs "value"
        ApplyColor(New Regex("""[^""]*"""), System.Drawing.Color.Brown)

        ' Entités HTML &nbsp; &amp; etc.
        ApplyColor(New Regex("&\w+;"), System.Drawing.Color.DarkGreen)
    End Sub

    Private Function ClassifyDiffLine(line As String) As DiffLineType
        If String.IsNullOrEmpty(line) Then
            Return DiffLineType.Context
        End If

        ' --- Métadonnées (entêtes diff) ---
        If line.StartsWith("@@") _
       OrElse line.StartsWith("diff ") _
       OrElse line.StartsWith("index ") _
       OrElse line.StartsWith("---") _
       OrElse line.StartsWith("+++") Then
            Return DiffLineType.Metadata
        End If

        ' --- Ajouts ---
        ' Attention : "+++" est déjà traité comme Metadata
        If line.StartsWith("+") Then
            Return DiffLineType.Added
        End If

        ' --- Suppressions ---
        ' Attention : "---" est déjà traité comme Metadata
        If line.StartsWith("-") Then
            Return DiffLineType.Removed
        End If

        ' --- Contexte (tout le reste) ---
        Return DiffLineType.Context
    End Function

    Private Sub ColorizeDiffLine(line As String, lineType As DiffLineType, rtb As RichTextBox)
        ' Position de départ dans le RichTextBox
        Dim start As Integer = rtb.TextLength

        ' Ajout de la ligne + retour à la ligne
        rtb.AppendText(line & Environment.NewLine)

        ' Sélection de la ligne ajoutée
        rtb.Select(start, line.Length)

        Select Case lineType

            Case DiffLineType.Added
                rtb.SelectionColor = System.Drawing.Color.Green

            Case DiffLineType.Removed
                rtb.SelectionColor = System.Drawing.Color.Red

            Case DiffLineType.Metadata
                rtb.SelectionColor = System.Drawing.Color.SteelBlue

            Case DiffLineType.Context
                rtb.SelectionColor = System.Drawing.Color.Black

            Case Else

        End Select

        ' Désélection
        rtb.SelectionLength = 0
    End Sub

    Private Sub ColorizeDiff(lines As IEnumerable(Of String), rtb As RichTextBox)
        ' On désactive les mises à jour visuelles pour éviter le scintillement
        rtb.SuspendLayout()
        rtb.Clear()

        For Each line As String In lines
            Dim t As DiffLineType = ClassifyDiffLine(line)
            ColorizeDiffLine(line, t, rtb)
        Next

        ' On remet l'affichage
        rtb.ResumeLayout()
    End Sub

    Public Sub LoadContent(contenu As String, extension As String, nomFichier As String)

        ViewerBox.Text = contenu
        Me.Text = nomFichier

        Select Case extension

            Case ".json"

                ' JSON minifié → on beautifie automatiquement
                If Not contenu.Contains(vbLf) Then
                    Try
                        Dim doc = JToken.Parse(contenu)
                        ViewerBox.Text = doc.ToString(Newtonsoft.Json.Formatting.Indented)
                    Catch
                        ' JSON invalide → on laisse tel quel
                    End Try
                End If

                ' Coloration JSON complète
                ColorizeJSON()

            Case ".csv"
                'ColorizeCsv()

            Case ".html", ".htm"
                'ColorizeHTML()

            Case ".css"
                'ColorizeCSS()

            Case ".toml"
                'ColorizeToml()

                ' Ajoute ici d'autres formats si nécessaire

        End Select

    End Sub

    Private Sub BeautifierJSONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeautifierJSONToolStripMenuItem.Click
        Try
            Dim contenu As String = ViewerBox.Text

            ' Parse le JSON
            Dim doc = JToken.Parse(contenu)

            ' Reformate avec indentation
            Dim pretty = doc.ToString(Newtonsoft.Json.Formatting.Indented)

            ' Réinjecte dans le Viewer
            ViewerBox.Text = pretty

            ' Recolorise automatiquement
            ColorizeJSON()

        Catch ex As Exception
            MessageBox.Show("Impossible de formater le JSON : " & ex.Message, "Erreur JSON", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MinifierJSONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MinifierJSONToolStripMenuItem.Click
        Try
            Dim contenu As String = ViewerBox.Text

            ' Parse le JSON
            Dim doc = JToken.Parse(contenu)

            ' Minifie (sans indentation)
            Dim compact = doc.ToString(Newtonsoft.Json.Formatting.None)

            ' Réinjecte dans le Viewer
            ViewerBox.Text = compact

            ' Recolorise automatiquement
            ColorizeJSON()

        Catch ex As Exception
            MessageBox.Show("Impossible de minifier le JSON : " & ex.Message, "Erreur JSON", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ViewerBox_MouseUp(sender As Object, e As MouseEventArgs) Handles ViewerBox.MouseUp
        If e.Button = MouseButtons.Left Then
            HandleUrlClick()
        End If
    End Sub

    Private Sub HandleUrlClick()
        Dim pos As Integer = ViewerBox.SelectionStart

        ' Récupère le mot sous le curseur
        Dim start As Integer = pos
        Dim finish As Integer = pos

        ' Étend vers la gauche
        While start > 0 AndAlso Not Char.IsWhiteSpace(ViewerBox.Text(start - 1)) AndAlso ViewerBox.Text(start - 1) <> """"c
            start -= 1
        End While

        ' Étend vers la droite
        While finish < ViewerBox.TextLength AndAlso Not Char.IsWhiteSpace(ViewerBox.Text(finish)) AndAlso ViewerBox.Text(finish) <> """"c
            finish += 1
        End While

        Dim word As String = ViewerBox.Text.Substring(start, finish - start)

        ' Vérifie si c'est une URL
        Dim urlRegex As New Regex("^https?://[^\s""']+$")
        If urlRegex.IsMatch(word) Then
            Try
                Process.Start(New ProcessStartInfo(word) With {.UseShellExecute = True})
            Catch ex As Exception
                MessageBox.Show("Impossible d'ouvrir l'URL : " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub ViewerBox_MouseMove(sender As Object, e As MouseEventArgs) Handles ViewerBox.MouseMove
        UpdateCursorForUrl()
    End Sub

    Private Sub UpdateCursorForUrl()
        Dim pos As Integer = ViewerBox.GetCharIndexFromPosition(ViewerBox.PointToClient(Cursor.Position))

        If pos < 0 OrElse pos >= ViewerBox.TextLength Then
            ViewerBox.Cursor = Cursors.IBeam
            Return
        End If

        ' Trouver le mot sous le curseur
        Dim start As Integer = pos
        Dim finish As Integer = pos

        ' Étend vers la gauche
        While start > 0 AndAlso Not Char.IsWhiteSpace(ViewerBox.Text(start - 1)) AndAlso ViewerBox.Text(start - 1) <> """"c
            start -= 1
        End While

        ' Étend vers la droite
        While finish < ViewerBox.TextLength AndAlso Not Char.IsWhiteSpace(ViewerBox.Text(finish)) AndAlso ViewerBox.Text(finish) <> """"c
            finish += 1
        End While

        Dim word As String = ViewerBox.Text.Substring(start, finish - start)

        ' Vérifie si c'est une URL
        Dim urlRegex As New Regex("^https?://[^\s""']+$")
        If urlRegex.IsMatch(word) Then
            ViewerBox.Cursor = Cursors.Hand
        Else
            ViewerBox.Cursor = Cursors.IBeam
        End If
    End Sub

End Class
Imports System.Text.RegularExpressions

Friend Module TomlHelpers

    ' ---------------------------------------------------------
    ' 1) Colorisation d'une ligne TOML dans un RichTextBox
    ' ---------------------------------------------------------
    Public Sub ColorizeTomlLine(line As String, rtb As RichTextBox)
        Dim start As Integer = rtb.TextLength

        rtb.AppendText(line & Environment.NewLine)
        rtb.Select(start, line.Length)

        ' --- Commentaires (# ...)
        If line.TrimStart().StartsWith("#") Then
            rtb.SelectionColor = Color.DarkGray
            rtb.SelectionLength = 0
            Exit Sub
        End If

        ' --- Tables ([section])
        If Regex.IsMatch(line.Trim(), "^

\[.*\]

$") Then
            rtb.SelectionColor = Color.SteelBlue
            rtb.SelectionLength = 0
            Exit Sub
        End If

        ' --- Clé = valeur
        Dim eqPos As Integer = line.IndexOf("="c)
        If eqPos > 0 Then
            ' Coloriser la clé
            rtb.Select(start, eqPos)
            rtb.SelectionColor = Color.RoyalBlue

            ' Coloriser la valeur
            Dim valueStart As Integer = start + eqPos + 1
            Dim valueText As String = line.Substring(eqPos + 1).Trim()

            ' Strings
            If valueText.StartsWith("""") AndAlso valueText.EndsWith("""") Then
                rtb.Select(valueStart, line.Length - eqPos - 1)
                rtb.SelectionColor = Color.IndianRed

                ' Booléens
            ElseIf valueText = "true" OrElse valueText = "false" Then
                rtb.Select(valueStart, line.Length - eqPos - 1)
                rtb.SelectionColor = Color.DarkGreen

                ' Nombres
            ElseIf Regex.IsMatch(valueText, "^[0-9\.\+\-]+$") Then
                rtb.Select(valueStart, line.Length - eqPos - 1)
                rtb.SelectionColor = Color.MediumPurple

                ' Tableaux
            ElseIf valueText.StartsWith("[") AndAlso valueText.EndsWith("]") Then
                rtb.Select(valueStart, line.Length - eqPos - 1)
                rtb.SelectionColor = Color.Black
            End If

            rtb.SelectionLength = 0
            Exit Sub
        End If

        ' --- Lignes normales
        rtb.SelectionColor = Color.Black
        rtb.SelectionLength = 0
    End Sub

    ' ---------------------------------------------------------
    ' 2) Colorisation complète d'un fichier TOML
    ' ---------------------------------------------------------
    Public Sub ColorizeToml(lines As IEnumerable(Of String), rtb As RichTextBox)
        rtb.SuspendLayout()
        rtb.Clear()

        For Each line In lines
            ColorizeTomlLine(line, rtb)
        Next

        rtb.ResumeLayout()
    End Sub

End Module
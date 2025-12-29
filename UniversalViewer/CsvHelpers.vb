Imports System.Text
Imports System.Windows.Forms

Friend Module CsvHelpers

    ' ---------------------------------------------------------
    ' 1) Détection automatique du séparateur
    ' ---------------------------------------------------------
    Public Function DetectCsvSeparator(lines As IEnumerable(Of String)) As Char
        Dim candidates As Char() = {";"c, ","c, ControlChars.Tab, "|"c}
        Dim bestSep As Char = ","c
        Dim bestScore As Integer = -1

        For Each sep In candidates
            Dim score As Integer = 0

            For Each line In lines.Take(20)
                Dim count = line.Count(Function(ch) ch = sep)
                score += count
            Next

            If score > bestScore Then
                bestScore = score
                bestSep = sep
            End If
        Next

        Return bestSep
    End Function


    ' ---------------------------------------------------------
    ' 2) Parsing d'une ligne CSV (gestion simple des guillemets)
    ' ---------------------------------------------------------
    Public Function ParseCsvLine(line As String, sep As Char) As List(Of String)
        Dim result As New List(Of String)
        Dim current As New StringBuilder()
        Dim insideQuotes As Boolean = False

        For Each ch In line
            If ch = """"c Then
                insideQuotes = Not insideQuotes
                current.Append(ch)

            ElseIf ch = sep AndAlso Not insideQuotes Then
                result.Add(current.ToString().Trim())
                current.Clear()

            Else
                current.Append(ch)
            End If
        Next

        result.Add(current.ToString().Trim())
        Return result
    End Function


    ' ---------------------------------------------------------
    ' 3) Calcul des largeurs maximales de colonnes
    ' ---------------------------------------------------------
    Public Function ComputeColumnWidths(rows As List(Of List(Of String))) As List(Of Integer)
        Dim widths As New List(Of Integer)

        For Each row In rows
            For I = 0 To row.Count - 1
                If widths.Count <= I Then widths.Add(0)
                widths(I) = Math.Max(widths(I), row(I).Length)
            Next
        Next

        Return widths
    End Function


    ' ---------------------------------------------------------
    ' 4) Alignement d'une ligne CSV selon les largeurs
    ' ---------------------------------------------------------
    Public Function AlignCsvRow(row As List(Of String), widths As List(Of Integer)) As String
        Dim parts As New List(Of String)

        For I = 0 To row.Count - 1
            parts.Add(row(I).PadRight(widths(I) + 2))
        Next

        Return String.Join("", parts)
    End Function


    ' ---------------------------------------------------------
    ' 5) Colorisation d'une ligne dans un RichTextBox
    ' ---------------------------------------------------------
    Public Sub ColorizeCsvLine(text As String, rowIndex As Integer, rtb As RichTextBox)
        Dim start As Integer = rtb.TextLength

        rtb.AppendText(text & Environment.NewLine)
        rtb.Select(start, text.Length)

        If rowIndex = 0 Then
            ' En-tête
            rtb.SelectionColor = Color.SteelBlue

        ElseIf rowIndex Mod 2 = 0 Then
            ' Lignes paires : léger fond gris
            rtb.SelectionBackColor = Color.FromArgb(20, 0, 0, 0)

        Else
            ' Lignes impaires : fond transparent
            rtb.SelectionBackColor = Color.Transparent
        End If

        rtb.SelectionLength = 0
    End Sub


    ' ---------------------------------------------------------
    ' 6) Colorisation complète d'un CSV dans un RichTextBox
    ' ---------------------------------------------------------
    Public Sub ColorizeCsv(lines As IEnumerable(Of String), rtb As RichTextBox)
        rtb.SuspendLayout()
        rtb.Clear()

        Dim sep As Char = DetectCsvSeparator(lines)

        Dim rows As New List(Of List(Of String))
        For Each line In lines
            rows.Add(ParseCsvLine(line, sep))
        Next

        Dim widths = ComputeColumnWidths(rows)

        For I = 0 To rows.Count - 1
            Dim aligned = AlignCsvRow(rows(I), widths)
            ColorizeCsvLine(aligned, I, rtb)
        Next

        rtb.ResumeLayout()
    End Sub

End Module
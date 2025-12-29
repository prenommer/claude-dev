' 🔹 Classe simple pour tri alphabétique sur une colonne donnée
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions

Friend Module Module1
    Private Declare Function LoadLibrary Lib "kernel32" Alias "LoadLibraryA" (lpLibFileName As String) As Long
    Private Declare Function FreeLibrary Lib "kernel32" (hLibModule As Long) As Long
    Private Declare Function SendMessageByString Lib "user32" Alias "SendMessageA" (hWnd As Long, wMsg As Long, wParam As Long, lParam As String) As Long

    Public Declare Function GetTickCount Lib "kernel32" () As Long
    Public Declare Function GetPixel Lib "gdi32" (
    hDC As Long,
    X As Long,
    Y As Long
    ) As Long

    Declare Function GetDefaultPrinter Lib "winspool.drv" Alias "GetDefaultPrinterA" (szPrinter As StringBuilder, ByRef bufferSize As Integer) As Boolean
    Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (szPrinter As String) As Boolean

    Public I, sauvé, modifié, ajouté, quitté, lit, supprimé, itemprevious, progress, Level As Integer
    Public enregistré, cboInit As Boolean
    Public locationprevious, FileSize, FileLength As Long
    Public preceding, selectionné As String

    Public FileNameQ As New List(Of String)
    Public ListeModules As List(Of String)
    Public Property ChercheItem As String
    Public Property StartFolder As String
    Public Property SpecialFolder As Long
    Public Property SzDisplay As String
    Public Property Dialogue As Boolean
    Public Property IndexEnreg As Integer

    <StructLayout(LayoutKind.Sequential, Pack:=4)>
    Public Structure WIN32_FIND_DATA
        Public dwFileAttributes As Integer
        Public ftCreationTime As Long
        Public ftLastAccessTime As Long
        Public ftLastWriteTime As Long
        Public nFileSizeHigh As UInteger
        Public nFileSizeLow As UInteger
        Public dwReserved0 As Integer
        Public dwReserved1 As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Public cFileName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=14)> Public cAlternate As String
    End Structure

    Public Const INVALID_HANDLE_VALUE As Long = -1

    'Constantes pour la clé et le vecteur d'initialisation
    'Public Const MyEncryptionKey As String = "VotreCléIci" ' Remplacer par GenerateRandomKey()
    'Public Const MyInitializationVector As String = "VotreVecteurIci" ' Remplacer par GenerateRandomIV()

    Public Structure FILETIME
        Public dwLowDateTime As Long
        Public dwHighDateTime As Long
    End Structure

    Declare Function FindFirstFile Lib "kernel32" Alias "FindFirstFileA" (lpFileName As String, lpFindFileData As WIN32_FIND_DATA) As Long
    Public Declare Function FindClose Lib "kernel32" (hFindFile As Long) As Long
    Public Declare Function PathFileExists Lib "shlwapi.dll" Alias "PathFileExistsA" (pszPath As String) As Long

    'Public Structure Article
    '<VBFixedString(18)> Public Title As String
    '<VBFixedString(90)> Public Name As String
    '<VBFixedString(120)> Public Charge As String
    '<VBFixedString(120)> Public Institute As String
    '<VBFixedString(120)> Public Celebration As String
    '<VBFixedString(120)> Public Birth As String
    '<VBFixedString(120)> Public Death As String
    '<VBFixedString(120)> Public Otherparties As String
    '<VBFixedString(120)> Public Othernames As String
    '<VBFixedString(120)> Public Venerable As String
    '<VBFixedString(120)> Public Beatified As String
    '<VBFixedString(120)> Public Canonized As String
    '<VBFixedString(120)> Public Heading As String
    '<VBFixedString(120)> Public Patron As String
    '<VBFixedString(120)> Public Link As String
    '<VBFixedString(120)> Public Image As String
    '<VBFixedString(1200)> Public Biography As String
    '<VBFixedString(200)> Public Origin As String
    'End Structure

    'Ne pas spécifier de CharSet est plus sûr ici
    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Public Structure Article_Binary

        ' Le champ est maintenant un tableau de Byte, taille égale au nombre d'octets UTF-8 max.
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public Title As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=90)> Public Name As Byte()
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=120)> Public Charge As Byte()
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=120)> Public Institute As Byte()
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=120)> Public Celebration As Byte()
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=120)> Public Birth As Byte()
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=120)> Public Death As Byte()
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=120)> Public Otherparties As Byte()
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=120)> Public Othernames As Byte()
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=120)> Public Venerable As Byte()
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=120)> Public Beatified As Byte()
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=120)> Public Canonized As Byte()
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=120)> Public Heading As Byte()
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=120)> Public Patron As Byte()
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=120)> Public Link As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=120)> Public Image As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1200)> Public Biography As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=200)> Public Origin As Byte()

    End Structure

    '<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Public Structure FicheArticle 'FicheArticleBinary
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)>
        Public Title As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=90)>
        Public Name As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=120)>
        Public Charge As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=120)>
        Public Institute As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=120)>
        Public Celebration As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=120)>
        Public Birth As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=120)>
        Public Death As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=120)>
        Public Otherparties As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=120)>
        Public Othernames As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=120)>
        Public Venerable As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=120)>
        Public Beatified As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=120)>
        Public Canonized As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=120)>
        Public Heading As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=120)>
        Public Patron As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=120)>
        Public Link As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=120)>
        Public Image As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1200)>
        Public Biography As Byte()

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=200)>
        Public Origin As Byte()
    End Structure

    Public Function BytesToStringField(bytes As Byte()) As String
        If bytes Is Nothing OrElse bytes.Length = 0 Then Return String.Empty
        Return Encoding.UTF8.GetString(bytes).TrimEnd(ChrW(0))
    End Function

    Public Structure ChampDef
        Public Nom As String
        Public Debut As Integer
        Public Fin As Integer
        Public LongueurMax As Integer
        Public NomAffiché As String
    End Structure

    Public Function StructureToByteArray(obj As Object) As Byte()

        '1. Calculer la taille requise
        Dim len As Integer = Marshal.SizeOf(obj)
        Dim arr(len - 1) As Byte

        '2. Allouer une zone de mémoire non managée
        Dim ptr As IntPtr = Marshal.AllocHGlobal(len)

        Try
            '3. Copier la structure vers le pointeur
            Marshal.StructureToPtr(obj, ptr, True)

            '4. Copier la mémoire non managée vers le tableau d'octets managé
            Marshal.Copy(ptr, arr, 0, len)
        Finally
            '5. Libérer la mémoire non managée (TRÈS IMPORTANT !)
            Marshal.FreeHGlobal(ptr)
        End Try

        Return arr

    End Function

    Public Articles As New List(Of FicheArticle)

    ' -------------------------------------------------------
    ' Déclaration de la fonction SHGetFileInfo dans la bibliothèque shell32.dll
    ' -------------------------------------------------------
    Public Const SHGFI_ICON As UInteger = &H100
    Public Const SHGFI_SMALLICON As UInteger = &H1
    Public Const SHGFI_USEFILEATTRIBUTES As UInteger = &H10

    <StructLayout(LayoutKind.Sequential)>
    Public Structure SHFILEINFO
        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As UInteger
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)>
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)>
        Public szTypeName As String
    End Structure

    <DllImport("Shell32.dll", CharSet:=CharSet.Unicode)>
    Public Function SHGetFileInfo(pszPath As String, dwFileAttributes As UInteger, ByRef psfi As SHFILEINFO, cbFileInfo As UInteger, uFlags As UInteger) As IntPtr
    End Function

    Public Property ID As Long
    Public Property Position As Integer
    Public Property Pointer As Long
    Public Property Changed As Boolean
    Public Property FileNameImage As String
    Public Property Bloqué As Boolean

    Public bIsModified As Boolean = False
    Public bNeedsFurtherProcessing As Boolean = False

    Public CurrentNode As TreeNode
    Public userInput As String
    Private userRole As String = "User" 'ou "Admin"

    'Public champs As List(Of ChampInfo)
    Public Function GetImgOFD(Frm As Form, PicBx As PictureBox) As Bitmap

        Dim _ErrBitmap As Bitmap = DocumentError_16x
        Dim ChosenBitmap As Bitmap

        Using OFD As New OpenFileDialog
            With OFD
                .Title = "Veuillez sélectionner un fichier"
                .InitialDirectory = My.Application.Info.DirectoryPath & "\Images\"
                .Filter = "Fichiers Image (*.ico;*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png;*.ico"
                .RestoreDirectory = True
                .Multiselect = False
                .CheckFileExists = True
                If .ShowDialog(Frm) = DialogResult.OK Then
                    ChosenBitmap = CType(Image.FromFile(.FileName), Bitmap)
                    FileNameImage = .FileName
                Else
                    ChosenBitmap = _ErrBitmap
                End If
            End With
        End Using
        Return ChosenBitmap

    End Function

    Public Sub FileListManager()

        'Liste des fichiers créés avec leurs chemins
        Dim CreatedFiles As New List(Of String)

    End Sub

    ' Ajouter un fichier à la liste
    Public Sub AddFile(filePath As String)

        CreatedFiles.Add(filePath)

    End Sub

    ' Tableau des longueurs fixes des champs dans la structure Article
    Public ReadOnly LongueursChamps As Integer() = {
        18,   'Title
        90,   'Name
        120,  'Charge
        120,  'Institute
        120,  'Celebration
        120,  'Birth
        120,  'Death
        120,  'Otherparties
        120,  'Othernames
        120,  'Venerable
        120,  'Beatified
        120,  'Canonized
        120,  'Heading
        120,  'Patron
        120,  'Link
        120,  'Image
        1200, 'Biography
        200   'Origin
    }

    '' Placez cette fonction DANS votre Module1.vb
    'Public Function ByteArrayToStructure(bytes() As Byte, type As Type) As Object

    'Dim expectedSize As Integer = Marshal.SizeOf(type)

    'If bytes.Length <> expectedSize Then
    'Throw New ArgumentException($"Erreur de taille : Tableau ({bytes.Length}) vs Structure ({expectedSize}).")
    'End If

    'Dim gch As GCHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned)
    'Dim pointer As IntPtr = gch.AddrOfPinnedObject()
    'Dim obj As Object = Nothing

    'Try
    '       ' Conversion
    '      obj = Marshal.PtrToStructure(pointer, type)
    'Finally
    '' Libération OBLIGATOIRE du handle après utilisation
    'If gch.IsAllocated Then
    '           gch.Free()
    'End If
    'End Try

    'Return obj
    'End Function

    Public Function ByteArrayToStructure(Of T)(bytes() As Byte) As T
        Dim expectedSize As Integer = Marshal.SizeOf(GetType(T))

        If bytes.Length <> expectedSize Then
            Throw New ArgumentException($"Erreur de taille : Tableau ({bytes.Length}) vs Structure ({expectedSize}).")
        End If

        Dim gch As GCHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned)
        Dim pointer As IntPtr = gch.AddrOfPinnedObject()

        Try
            Return DirectCast(Marshal.PtrToStructure(pointer, GetType(T)), T)
        Finally
            If gch.IsAllocated Then
                gch.Free()
            End If
        End Try
    End Function

    '******************************************************
    ' DANS VOTRE MODULE OU CLASSE (À DÉCLARER UNE SEULE FOIS)
    '******************************************************

    'Cette fonction prend une valeur de colonne en entrée et retourne une chaîne nettoyée.
    Public Function GetSafeColumnValue(columnValue As Object) As String
        'Si la valeur est Nothing ou DBNull, retourne une chaîne vide.
        If IsNothing(columnValue) OrElse TypeOf columnValue Is DBNull Then
            Return String.Empty
        Else
            ' Sinon, convertit, nettoie et met en minuscules.
            Return CStr(columnValue).Trim().ToLower()
        End If
    End Function

    Public Function IsTomlFormat(lines As IEnumerable(Of String)) As Boolean
        Dim score As Integer = 0

        For Each line In lines.Take(20)
            Dim trimmed = line.Trim()

            ' Table : [section]
            If Regex.IsMatch(trimmed, "^

\[[^\]

]+\]

$") Then
                score += 2
                Continue For
            End If

            ' Table imbriquée : [[section]]
            If Regex.IsMatch(trimmed, "^

\[

\[[^\]

]+\]

\]

$") Then
                score += 2
                Continue For
            End If

            ' Commentaire
            If trimmed.StartsWith("#") Then
                score += 1
                Continue For
            End If

            ' Clé = valeur
            If trimmed.Contains("="c) Then
                Dim parts = trimmed.Split("="c)
                If parts.Length = 2 AndAlso Regex.IsMatch(parts(0).Trim(), "^[A-Za-z0-9_\-\.]+$") Then
                    score += 2
                    Continue For
                End If
            End If

            ' Tableau : [ ... ]
            If trimmed.StartsWith("[") AndAlso trimmed.EndsWith("]") Then
                score += 1
                Continue For
            End If
        Next

        Return score >= 3
    End Function

    Public Function IsCsvFormat(lines As IEnumerable(Of String)) As Boolean
        Dim first = lines.FirstOrDefault()
        If first Is Nothing Then Return False

        Return first.Contains(";") OrElse first.Contains(",") OrElse first.Contains(vbTab)
    End Function

    Public Function IsDiffFormat(lines As IEnumerable(Of String)) As Boolean
        Dim score As Integer = 0

        For Each line In lines.Take(20)
            Dim trimmed = line.TrimStart()

            If trimmed.StartsWith("---") Then score += 2
            If trimmed.StartsWith("+++") Then score += 2
            If trimmed.StartsWith("@@") Then score += 2
            If trimmed.StartsWith("-") Then score += 1
            If trimmed.StartsWith("+") Then score += 1
        Next

        Return score >= 3
    End Function

End Module
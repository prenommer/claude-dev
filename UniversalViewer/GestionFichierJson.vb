Imports System.IO
Imports Newtonsoft.Json

Public Class GestionFichierJson
    Private p As New Fich

    Public Sub RemplirDonnees(titre As String, nom As String, charge As String, institut As String, celebration As String, naissance As String, deces As String, autresfetes As String, autresnoms As String, venerable As String, beatification As String, canonisation As String, titreprincipal As String, patron As String, lien As String, image As String, biographie As String, origine As String)

        p.Titre = titre
        p.Nom = nom
        p.Charge = charge
        p.Institut = institut
        p.Celebration = celebration
        p.Naissance = naissance
        p.Deces = deces
        p.Autresfetes = autresfetes
        p.Autresnoms = autresnoms
        p.Venerable = venerable
        p.Beatification = beatification
        p.Canonisation = canonisation
        p.TitrePrincipal = titreprincipal
        p.Patron = patron
        p.Lien = lien
        p.Image = image
        p.Biographie = biographie
        p.Origine = origine

    End Sub

    Public Sub SauvegarderJson(chemin As String)
        Try
            Dim jsonString As String = JsonConvert.SerializeObject(p, Formatting.Indented)
            File.WriteAllText(chemin, jsonString)
            MessageBox.Show("Fichier JSON créé avec succès : " & chemin, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la sauvegarde : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
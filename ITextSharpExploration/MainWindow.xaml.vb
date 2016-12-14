Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Class MainWindow


    Private Sub HelloWord_Click(sender As Object, e As RoutedEventArgs) Handles HelloWorldButton.Click
        Dim myDocument As Document = New Document()

        Try
            PdfWriter.GetInstance(myDocument, New FileStream("hello world.pdf", FileMode.Create))
            myDocument.OpenDocument()
            myDocument.Add(New Phrase("hello world"))
        Catch ex As DocumentException
            Console.WriteLine(ex.Message)
        Finally
            myDocument.CloseDocument()
        End Try
    End Sub

    Private Sub StylizeButton_Click(sender As Object, e As RoutedEventArgs) Handles StylizeButton.Click
        Dim myDocument As Document = New Document()

        Try
            PdfWriter.GetInstance(myDocument, New FileStream("text with style.pdf", FileMode.Create))
            myDocument.OpenDocument()

            Dim myChunk As Chunk = New Chunk("Text with style", FontFactory.GetFont(FontFactory.COURIER, 20, Font.BOLDITALIC, New BaseColor(25, 25, 255)))
            myChunk.SetBackground(BaseColor.GREEN)
            myDocument.Add(myChunk)
        Catch ex As DocumentException
            Console.WriteLine(ex.Message)
        Finally
            myDocument.CloseDocument()
        End Try
    End Sub

    Private Sub ListButton_Click(sender As Object, e As RoutedEventArgs) Handles ListButton.Click
        Dim myDocument As Document = New Document()

        Try
            PdfWriter.GetInstance(myDocument, New FileStream("Make a list.pdf", FileMode.Create))
            myDocument.OpenDocument()

            Dim myList As List = New List(False, True)
            myList.Add(New ListItem("My first item"))
            myList.Add(New ListItem("My second item"))
            myDocument.Add(myList)
        Catch ex As DocumentException
            Console.WriteLine(ex.Message)
        Finally
            myDocument.CloseDocument()
        End Try
    End Sub

    Private Sub ImageButton_Click(sender As Object, e As RoutedEventArgs) Handles ImageButton.Click
        Dim myDocument As Document = New Document()

        Try
            PdfWriter.GetInstance(myDocument, New FileStream("Some art.pdf", FileMode.Create))
            myDocument.OpenDocument()

            Dim myImage As Image = Image.GetInstance("..\..\..\Resources\balloons.jpg")
            myImage.ScalePercent(20)
            myDocument.Add(myImage)
        Catch ex As DocumentException
            Console.WriteLine(ex.Message)
        Finally
            myDocument.CloseDocument()
        End Try
    End Sub

    Private Sub TableButton_Click(sender As Object, e As RoutedEventArgs) Handles TableButton.Click
        Dim myDocument As Document = New Document()

        Try
            PdfWriter.GetInstance(myDocument, New FileStream("Table time.pdf", FileMode.Create))
            myDocument.OpenDocument()

            Dim myTable As PdfPTable = New PdfPTable(4)
            myTable.DefaultCell.Border = Rectangle.NO_BORDER
            Dim myHeader As PdfPCell = New PdfPCell(New Paragraph("My super title"))
            myHeader.Colspan = 4
            myTable.AddCell(myHeader)

            Dim numberHeaderCell As PdfPCell = New PdfPCell(New Phrase("Number", FontFactory.GetFont(FontFactory.COURIER, 20, Font.BOLD, New BaseColor(255, 0, 255))))
            numberHeaderCell.Border = 0
            myTable.AddCell(numberHeaderCell)

            Dim nameHeaderCell As PdfPCell = New PdfPCell(New Phrase("Name", FontFactory.GetFont(FontFactory.COURIER, 20, Font.BOLD, New BaseColor(255, 0, 255))))
            numberHeaderCell.Border = 0
            myTable.AddCell(nameHeaderCell)

            Dim addressHeaderCell As PdfPCell = New PdfPCell(New Phrase("Address", FontFactory.GetFont(FontFactory.COURIER, 20, Font.BOLD, New BaseColor(255, 0, 255))))
            numberHeaderCell.Border = 0
            myTable.AddCell(addressHeaderCell)

            Dim phoneNumberHeaderCell As PdfPCell = New PdfPCell(New Phrase("Phone number", FontFactory.GetFont(FontFactory.COURIER, 20, Font.BOLD, New BaseColor(255, 0, 255))))
            numberHeaderCell.Border = 0
            myTable.AddCell(phoneNumberHeaderCell)

            myTable.CompleteRow()
            myTable.AddCell("1")
            myTable.AddCell("Bob")
            myTable.AddCell("101 Lost")
            myTable.AddCell("444-1919")

            myDocument.Add(myTable)
        Catch ex As DocumentException
            Console.WriteLine(ex.Message)
        Finally
            myDocument.CloseDocument()
        End Try
    End Sub
End Class

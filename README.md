// method name
 
 
 public void UploadFile(Stream stream)
 {
     // Ensure EPPlus is properly configured
     ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
     using (var package = new ExcelPackage(stream))
     {
         var worksheet = package.Workbook.Worksheets[0]; // Get the first worksheet

         var rowCount = worksheet.Dimension.Rows; // Get number of rows
         for (int row = 2; row <= rowCount; row++) // Start from row 2 to skip header
         {
             var Customer = new Customer()
             {
                 Name = worksheet.Cells[row, 1].Value.ToString(),
                 Age = Convert.ToInt16(worksheet.Cells[row, 2].Value.ToString())
             };
             _webDbContext.Customers.Add(Customer);
             
             
         }
         _webDbContext.SaveChanges();

     }
 }




 // controller

  public void Post([FromForm] ExcelFileUploadModel model)
 {  
     try
     {
         using (var stream = new MemoryStream())
         {
             model.formFile.CopyTo(stream);
             excelCreatorEPPLUS.UploadFile(stream);
         }

     }
     catch
     {

     }

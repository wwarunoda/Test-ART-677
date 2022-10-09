using Domain;
using OfficeOpenXml;


namespace Infrastructure.Persistence.Configurations
{
    public class FileConfiguration<T>
    {
        public FileConfiguration()
        {
            // If you are a commercial business and have
            // purchased commercial licenses use the static property
            // LicenseContext of the ExcelPackage class :
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public IEnumerable<T> GetFileData(string fileName, string spreadSheetName)
        {
            var file = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName));
            using (var package = new ExcelPackage(file))
            {
                List<T> data = new List<T>();
                var workSheet = package.Workbook.Worksheets[spreadSheetName];
                var start = workSheet.Dimension.Start;
                var end = workSheet.Dimension.End;
                if (typeof(T) == typeof(Estimate))
                {
                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        var estimate = new Estimate()
                        {
                            State = Convert.ToInt32(workSheet.Cells[row, 1].Value),
                            District = workSheet.Cells[row, 2].Value?.ToString(),
                            Population = Convert.ToDecimal(workSheet.Cells[row, 3].Value),
                            Household = Convert.ToDecimal(workSheet.Cells[row, 4].Value)
                            
                        };
       
                        data.Add((T)Convert.ChangeType(estimate, typeof(T)));
                    }
                } else
                {
                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        var estimate = new Actual()
                        {
                            State = Convert.ToInt32(workSheet.Cells[row, 1].Value),
                            Population = Convert.ToDecimal(workSheet.Cells[row, 2].Value),
                            Household = Convert.ToDecimal(workSheet.Cells[row, 3].Value)
                        };

                        data.Add((T)Convert.ChangeType(estimate, typeof(T)));
                    }
                }
                return data;
            }
        }
    }
}

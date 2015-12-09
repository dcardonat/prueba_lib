namespace Libellus.Utilidades
{
    using System.Collections.Generic;
    using System.IO;
    using ClosedXML.Excel;

    /// <summary>
    /// Proporciona el mecanismo de exportar a Excel.
    /// </summary>
    public static class ExportarExcel
    {
        #region Métodos públicos

        /// <summary>
        /// Exporta información a Excel.
        /// </summary>
        /// <param name="registrosExportar">Lista de registros a exportar.</param>
        /// <param name="nombreHojaExcel"></param>
        /// <returns>Arra de bytes del archivo de excel exportado.</returns>
        public static byte[] Exportar<T>(List<T> registrosExportar, string nombreHojaExcel)
        {
            byte[] byteArray = null;

            using (XLWorkbook libroExcel = new XLWorkbook())
            {
                using (IXLWorksheet hojaExcel = libroExcel.Worksheets.Add(nombreHojaExcel))
                {
                    hojaExcel.Cell(1, 1).InsertTable(registrosExportar, false);
                    EstablecerEstilosExportacionExcel(hojaExcel);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        libroExcel.SaveAs(memoryStream);
                        byteArray = memoryStream.ToArray();
                    }
                }
            }

            return byteArray;
        }

        #endregion

        #region Métodos privados

        /// <summary>
        /// Establece los estilos para el archivo que se exporta a Excel.
        /// </summary>
        /// <param name="hojaExcel">Información de la hoja de excel a establecer estilos.</param>
        private static void EstablecerEstilosExportacionExcel(IXLWorksheet hojaExcel)
        {
            hojaExcel.SheetView.FreezeRows(1);

            hojaExcel.Rows("1").CellsUsed().Style.Fill.BackgroundColor = XLColor.FromArgb(21, 106, 193);
            hojaExcel.Rows("1").CellsUsed().Style.Font.FontColor = XLColor.White;
            hojaExcel.Rows("1").CellsUsed().Style.Font.Bold = true;

            hojaExcel.Rows("1").CellsUsed().Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            hojaExcel.Rows("1").CellsUsed().Style.Border.InsideBorderColor = XLColor.Black;

            hojaExcel.Rows("1").CellsUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            hojaExcel.Rows("1").CellsUsed().Style.Border.OutsideBorderColor = XLColor.Black;

            hojaExcel.ColumnsUsed().AdjustToContents();
        }

        #endregion
    }
}

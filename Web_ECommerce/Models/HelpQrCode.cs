﻿using Entities.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web_ECommerce.Models
{
    public class HelpQrCode : Controller
    {
        private async Task<byte[]> GeraQrCode(string dadosBanco)
        {
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();

            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(dadosBanco, QRCodeGenerator.ECCLevel.H);

            QRCode qRCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qRCode.GetGraphic(20);

            var bitmapBytes = BitmapToBytes(qrCodeImage);

            return bitmapBytes;
        }
        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                return stream.ToArray();
            }
        }

        public async Task<IActionResult> Download(CompraUsuario compraUsuario, IWebHostEnvironment _environment)
        {
            using (var doc = new PdfSharpCore.Pdf.PdfDocument())
            {
                #region Configurações da folha
                var page = doc.AddPage();

                page.Size = PdfSharpCore.PageSize.A4;
                page.Orientation = PdfSharpCore.PageOrientation.Portrait;

                var graphics = XGraphics.FromPdfPage(page);
                var corFonte = XBrushes.Black;
                #endregion

                #region Numeração das Paginas
                int qtdPaginas = doc.PageCount;

                var numeracaoPagina = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
                numeracaoPagina.DrawString(Convert.ToString(qtdPaginas), new PdfSharpCore.Drawing.XFont("Arial", 10), corFonte, new PdfSharpCore.Drawing.XRect(575, 825, page.Width, page.Height));
                #endregion

                #region Logo
                var WebRoot = _environment.WebRootPath;

                var logoFatura = string.Concat(WebRoot, "/img/", "NeyLogoNFK.jpeg");

                XImage imagem = XImage.FromFile(logoFatura);

                graphics.DrawImage(imagem, 20, 5, 300, 50);
                #endregion

                #region Informações 1
                var relatorioCobranca = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);

                var titulo = new PdfSharpCore.Drawing.XFont("Arial", 14, PdfSharpCore.Drawing.XFontStyle.Bold);

                relatorioCobranca.Alignment = PdfSharpCore.Drawing.Layout.XParagraphAlignment.Center;

                relatorioCobranca.DrawString("Boleto ONLINE NKF SmartPhones", titulo, corFonte, new XRect(0, 65, page.Width, page.Height));
                #endregion

                #region Informações 2
                var alturaTituloDetalhesY = 120;

                var detalhes = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);

                var tituloInfo_1 = new PdfSharpCore.Drawing.XFont("Arial", 8, XFontStyle.Regular);

                detalhes.DrawString("Dados do banco", tituloInfo_1, corFonte, new XRect(25, alturaTituloDetalhesY, page.Width, page.Height));
                detalhes.DrawString("Itau 351", tituloInfo_1, corFonte, new XRect(150, alturaTituloDetalhesY, page.Width, page.Height));

                alturaTituloDetalhesY += 9;
                detalhes.DrawString("Codigo gerado", tituloInfo_1, corFonte, new XRect(25, alturaTituloDetalhesY, page.Width, page.Height));
                detalhes.DrawString("000000 000000 000000 000000", tituloInfo_1, corFonte, new XRect(150, alturaTituloDetalhesY, page.Width, page.Height));

                alturaTituloDetalhesY += 9;
                detalhes.DrawString("Quantidade: ", tituloInfo_1, corFonte, new XRect(25, alturaTituloDetalhesY, page.Width, page.Height));
                detalhes.DrawString(compraUsuario.QunatidadeProdutos.ToString(), tituloInfo_1, corFonte, new XRect(150, alturaTituloDetalhesY, page.Width, page.Height));

                alturaTituloDetalhesY += 9;
                detalhes.DrawString("Valor Total: ", tituloInfo_1, corFonte, new XRect(25, alturaTituloDetalhesY, page.Width, page.Height));
                detalhes.DrawString(compraUsuario.QunatidadeProdutos.ToString(), tituloInfo_1, corFonte, new XRect(150, alturaTituloDetalhesY, page.Width, page.Height));

                var tituloInfo_2 = new PdfSharpCore.Drawing.XFont("Arial", 8, XFontStyle.Bold);

                try
                {
                    var img = await GeraQrCode("Dados do banco");
                    Stream streamImage = new MemoryStream(img);

                    XImage qrConde = XImage.FromStream(() => streamImage);

                    alturaTituloDetalhesY += 40;
                    graphics.DrawImage(qrConde, 140, alturaTituloDetalhesY, 310, 310);
                }
                catch (Exception erro)
                {

                    
                }

                alturaTituloDetalhesY += 620;
                detalhes.DrawString("Canhoto com QrCode para pagamento OnLine. ", tituloInfo_2, corFonte, new XRect(20, alturaTituloDetalhesY, page.Width, page.Height));

                #endregion

                using (MemoryStream stream = new MemoryStream())
                {
                    var contentType = "application/pdf";
                    doc.Save(stream, false);
                    return File(stream.ToArray(), contentType, "Boleto-NFK-SmartPhones.pdf");
                }


            }
        }
    }
}

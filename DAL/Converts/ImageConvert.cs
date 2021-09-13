using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Converts
{
    public static class ImageConvert
    {
        public static Imajes ConvertCityToEF(ImageModel img)
        {
            return new Imajes
            {
                CodeImaje = img.CodeImaje,
                CodeProduct = img.CodeProduct,
                PuthImaje1 = img.PuthImaje1,
                PuthImaje2 = img.PuthImaje2,
                PuthImaje3 = img.PuthImaje3,

            };
        }
        public static ImageModel ConvertImageToModel(Imajes img)
        {
            return new ImageModel
            {
                CodeImaje = img.CodeImaje,
                CodeProduct = img.CodeProduct,
                PuthImaje1 = img.PuthImaje1,
                PuthImaje2 = img.PuthImaje2,
                PuthImaje3 = img.PuthImaje3,
            };
        }

        public static List<ImageModel> ConvertImageyListToModel(IEnumerable<Imajes> img)
        {
            return img.Select(c => ConvertImageToModel(c)).OrderBy(n => n.CodeImaje).ToList();
        }
    }
}

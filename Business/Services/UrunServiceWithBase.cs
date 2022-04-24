using AppCore.Business.Models.Results;
using AppCore.Business.Services.Bases;
using AppCore.DataAccess.EntityFramework;
using AppCore.DataAccess.EntityFramework.Bases;
using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;
using System.Globalization;

namespace Business.Services

{
    public interface IUrunService : IService<UrunModel, Urun, ETicaretContext>
    {

    }
    public class UrunService : IUrunService
    {
        public RepoBase<Urun, ETicaretContext> Repo { get; set; } = new Repo<Urun, ETicaretContext>();

        public Result Add(UrunModel model)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Repo.Dispose();
        }

        public IQueryable<UrunModel> Query()
        {
            return Repo.Query().OrderBy(u => u.Adi).Select(u => new UrunModel()
            {
                Aciklamasi = u.Aciklamasi,
                Adi = u.Adi,
                BirimFiyati = u.BirimFiyati,
                KategoriId = u.KategoriId,
                SonKullanmaTarihi = u.SonKullanmaTarihi,
                StokMiktari = u.StokMiktari,

                BirimFiyatiDisplay = u.BirimFiyati.ToString("C2", new CultureInfo("tr-TR")),

                SonKullanmaTarihiDisplay = u.SonKullanmaTarihi.HasValue ? u.SonKullanmaTarihi.Value.ToString("dd.MM.yyyy") : ""


            });
        }

        public Result Update(UrunModel model)
        {
            throw new NotImplementedException();
        }
    }
}

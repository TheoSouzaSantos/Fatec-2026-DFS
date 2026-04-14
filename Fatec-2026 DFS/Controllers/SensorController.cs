using Fatec_2026_DFS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fatec_2026_DFS.Controllers
{
    public class SensorController : Controller
    {
        // GET: SensorController
        public ActionResult Index()
        {
            var lista = LerLista();
            return View(lista);
        }

        private List<Sensor> IniciarLista()
        {
            List<Sensor> lista = Sensor.Lista;
            AtualizarLista(lista);
            return lista;
        }

        private List<Sensor> LerLista()
        {
            List<Sensor> lista;
            string sensores = HttpContext.Session.GetString("sensores");
            if (!string.IsNullOrEmpty(sensores))
            {
                lista = JsonConvert.DeserializeObject<List<Sensor>>(sensores);
                if (lista.Count == 0)
                {
                    IniciarLista();
                }
            }
            else
            {
                lista = IniciarLista();
            }
            return lista;
        }

        private void AtualizarLista(List<Sensor> lista)
        {

            string sensores = JsonConvert.SerializeObject(lista);
            HttpContext.Session.SetString("sensores", sensores);

        }

        // GET: SensorController/Details/5
        public ActionResult Details(int id)
        {
            var lista = LerLista();
            return View(lista[id]);
        }

        // GET: SensorController/Create
        public ActionResult Create()
        {
            return View(new Sensor());
        }

        // POST: SensorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sensor sensor)
        {
            try
            {
                var lista = LerLista();
                lista.Add(sensor);
                AtualizarLista(lista);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SensorController/Edit/5
        public ActionResult Edit(int id)
        {
            var lista = LerLista();
            return View(lista[id]);
        }

        // POST: SensorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Sensor sensor)
        {
            try
            {
                var lista = LerLista();
                lista[id] = sensor;
                AtualizarLista(lista);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SensorController/Delete/5
        public ActionResult Delete(int id)
        {
            var lista = LerLista();

            return View(lista[id]);
        }

        // POST: SensorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Sensor sensor)
        {
            try
            {
                var lista = LerLista();
                lista.RemoveAt(id);
                AtualizarLista(lista);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

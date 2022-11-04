using System.Collections.Generic;
using Shared.Interfaces;
using Shared.Dto;

namespace DAL
{
    // For now, data is either a json file or hard-coded values called here.
    public class TaspaData : ITaspaData
    {
        public List<NavigationLink> GetNavigationLinks()
        {
            var navigationLinks = new List<NavigationLink>();

            navigationLinks.Add(new NavigationLink() { LinkAction = "/Index", LinkText = "Home" });
            navigationLinks.Add(new NavigationLink() { LinkAction = "/Panels/VerbsPanel", LinkText = "Verbs" });
            navigationLinks.Add(new NavigationLink() { LinkAction = "/Panels/VocabularyPanel", LinkText = "Vocabulary" });

            return navigationLinks;
        }

        #region Vocabulary Lists

        public List<string> GetVocabularyLists()
        {
            var verbLists = new List<string>();

            verbLists.Add("Select list");
            verbLists.Add("Full");
            verbLists.Add("A");
            //verbLists.Add("B");
            //verbLists.Add("C");
            //verbLists.Add("D");
            //verbLists.Add("E");
            //verbLists.Add("F");
            //verbLists.Add("G");
            //verbLists.Add("H");
            //verbLists.Add("I");
            //verbLists.Add("J");
            //verbLists.Add("K");
            //verbLists.Add("L");
            //verbLists.Add("M");
            //verbLists.Add("N");
            //verbLists.Add("O");
            //verbLists.Add("P");
            //verbLists.Add("Q");
            //verbLists.Add("R");
            //verbLists.Add("S");
            //verbLists.Add("T");
            //verbLists.Add("U");
            //verbLists.Add("V");
            //verbLists.Add("W");
            //verbLists.Add("X");
            //verbLists.Add("Y");
            //verbLists.Add("Z");

            return verbLists;
        }
        public List<string> GetVocabularyList_HouseTerms()
        {
            var list = new List<string>();

            list.Add("el_ático");
            list.Add("el_armario");
            list.Add("el_baño");
            list.Add("el_comedor");
            list.Add("el_cuarto");
            list.Add("el_dormitorio");
            list.Add("el_enchufe");
            list.Add("el_espejo");
            list.Add("el_estudio");
            list.Add("el_fregadero");
            list.Add("el_garage");
            list.Add("el_grifo");
            list.Add("el_horno");
            list.Add("el_lavavajillas");
            list.Add("el_mostrador");
            list.Add("el_muro");
            list.Add("el_patio");
            list.Add("el_piso");
            list.Add("el_ropero");
            list.Add("el_sofá");
            list.Add("el_suelo");
            list.Add("el_sótano");
            list.Add("el_techo");
            list.Add("el_tejado");
            list.Add("el_váter");
            list.Add("la_aspiradora");
            list.Add("la_cama");
            list.Add("la_cocina");
            list.Add("la_cómoda");
            list.Add("la_entrada");
            list.Add("la_escalera");
            list.Add("la_estancia");
            list.Add("la_estufa");
            list.Add("la_lavadora");        
            list.Add("la_licuadora");
            list.Add("la_luz");
            list.Add("la_lámpara");
            list.Add("la_mesa");
            list.Add("la_pared");
            list.Add("la_plancha");
            list.Add("la_puerta");
            list.Add("la_sala_de_estar");
            list.Add("la_secadora");
            list.Add("la_silla");
            list.Add("la_tostadora");
            list.Add("la_ventana");

            return list;
        }
        public List<string> GetVocabularyList_Phrases()
        {
            var list = new List<string>();

            list.Add("alguein_tiene_prisa");
            list.Add("anthro");
            list.Add("asuntos_de_seguridad");
            list.Add("buena_onda");
            list.Add("cabruyendo");
            list.Add("cabrón");
            list.Add("cedo");
            list.Add("chispa");
            list.Add("echarle_un_ojo_los_gatos");
            list.Add("estoy_bien_tal_como_soy");
            list.Add("fugaz");
            list.Add("la_hielera");
            list.Add("mendingo");
            list.Add("necio");
            list.Add("no_sea_chochino");
            list.Add("que_tan_lejos_corriste");
            list.Add("quiero_pasar_los_años_que_me_quedan_sanos");
            list.Add("racimo_de_plátanos");
            list.Add("rapiño");
            list.Add("talcón");
            list.Add("te_cuesta_moverte");
            list.Add("un_par");
            list.Add("vas_a_poder");

            return list;
        }
        public List<string> GetVocabularyList_TheBody()
        {
            var list = new List<string>();

            list.Add("el_brazo");
            list.Add("el_cerebro");
            list.Add("el_codo");
            list.Add("el_corazón");
            list.Add("el_cuello");
            list.Add("el_dedo");
            list.Add("el_diente");
            list.Add("el_estómago");
            list.Add("el_hombro");
            list.Add("el_hígado");
            list.Add("el_intestino");
            list.Add("el_muslo");
            list.Add("el_músculo");
            list.Add("el_ojo");
            list.Add("el_oído");
            list.Add("el_pecho");
            list.Add("el_pelo");
            list.Add("el_pie");
            list.Add("el_vientre");
            list.Add("las_nalgas");
            list.Add("la_boca");
            list.Add("la_cabeza");
            list.Add("la_cadera");
            list.Add("la_columna_vertebral");
            list.Add("la_espalda");
            list.Add("la_garganta");
            list.Add("la_lengua");
            list.Add("la_mano");
            list.Add("la_nariz");
            list.Add("la_pantorrilla");
            list.Add("la_piel");
            list.Add("la_pierna");
            list.Add("la_rodilla");

            return list;
        }

        #endregion

        #region Verbs

        public List<string> GetVerbLists()
        {
            var verbLists = new List<string>();

            verbLists.Add("Select list");
            verbLists.Add("Full");
            verbLists.Add("A");
            verbLists.Add("B");
            verbLists.Add("C");
            verbLists.Add("D");
            verbLists.Add("E");
            verbLists.Add("F");
            verbLists.Add("G");
            verbLists.Add("H");
            verbLists.Add("I");
            verbLists.Add("J");
            //verbLists.Add("K");
            verbLists.Add("L");
            verbLists.Add("M");
            verbLists.Add("N");
            verbLists.Add("O");
            verbLists.Add("P");
            verbLists.Add("Q");
            verbLists.Add("R");
            verbLists.Add("S");
            verbLists.Add("T");
            verbLists.Add("U");
            verbLists.Add("V");
            //verbLists.Add("W");
            //verbLists.Add("X");
            //verbLists.Add("Y");
            verbLists.Add("Z");

            return verbLists;
        }
        public List<string> GetAVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("abrazar");
            currentVerbList.Add("abrir");
            currentVerbList.Add("acabar");
            currentVerbList.Add("aceptar");
            currentVerbList.Add("acercar");
            currentVerbList.Add("aconsejar");
            currentVerbList.Add("acordar");
            currentVerbList.Add("acostar");
            currentVerbList.Add("acudir");
            currentVerbList.Add("adelgazar");
            currentVerbList.Add("adivinar");
            currentVerbList.Add("admitir");
            currentVerbList.Add("adoptar");
            currentVerbList.Add("afeitar");
            currentVerbList.Add("agradar");
            currentVerbList.Add("agarrar");
            currentVerbList.Add("aguantar");
            currentVerbList.Add("ahogar");
            currentVerbList.Add("alcanzar");
            currentVerbList.Add("alejar");
            currentVerbList.Add("alegrar");
            currentVerbList.Add("aletear");
            currentVerbList.Add("almorzar");
            currentVerbList.Add("alquilar");
            currentVerbList.Add("amanecer");
            currentVerbList.Add("amenazar");
            currentVerbList.Add("amar");
            currentVerbList.Add("andar");
            currentVerbList.Add("anotar");
            currentVerbList.Add("apagar");
            currentVerbList.Add("aparecer");
            currentVerbList.Add("aprender");
            currentVerbList.Add("apretar");
            currentVerbList.Add("aprobar");
            currentVerbList.Add("apapachar");
            currentVerbList.Add("apelar");
            currentVerbList.Add("arreglar");
            currentVerbList.Add("arrancar");
            currentVerbList.Add("arrepentir");
            currentVerbList.Add("arruinar");
            currentVerbList.Add("asistir");
            currentVerbList.Add("aspirar");
            currentVerbList.Add("atender");
            currentVerbList.Add("aterrizar");
            currentVerbList.Add("atracar");
            currentVerbList.Add("averiguar");
            currentVerbList.Add("ayudar");
            currentVerbList.Add("azotar");

            return currentVerbList;
        }
        public List<string> GetBVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("bailar");
            currentVerbList.Add("bajar");
            currentVerbList.Add("beber");
            currentVerbList.Add("borrar");
            currentVerbList.Add("botar");
            currentVerbList.Add("brillar");
            currentVerbList.Add("buscar");

            return currentVerbList;
        }
        public List<string> GetCVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("caber");
            currentVerbList.Add("calentar");
            currentVerbList.Add("cambiar");
            currentVerbList.Add("caminar");
            currentVerbList.Add("cantar");
            currentVerbList.Add("cansar");
            currentVerbList.Add("casar");
            currentVerbList.Add("causar");
            currentVerbList.Add("cavar");
            currentVerbList.Add("cazar");
            currentVerbList.Add("cenar");
            currentVerbList.Add("cerrar");
            currentVerbList.Add("charlar");
            currentVerbList.Add("chocar");
            currentVerbList.Add("chupar");
            currentVerbList.Add("cocinar");
            currentVerbList.Add("coger");
            currentVerbList.Add("colocar");
            currentVerbList.Add("colgar");
            currentVerbList.Add("comenzar");
            currentVerbList.Add("comer");
            currentVerbList.Add("comprar");
            currentVerbList.Add("comprender");
            currentVerbList.Add("conducir");
            currentVerbList.Add("confiar");
            currentVerbList.Add("conocer");
            currentVerbList.Add("construir");
            currentVerbList.Add("contar");
            currentVerbList.Add("contestar");
            currentVerbList.Add("conversar");
            currentVerbList.Add("corregir");
            currentVerbList.Add("correr");
            currentVerbList.Add("cortar");
            currentVerbList.Add("costar");
            currentVerbList.Add("coser");
            currentVerbList.Add("crear");
            currentVerbList.Add("crecer");
            currentVerbList.Add("creer");
            currentVerbList.Add("cruzar");
            currentVerbList.Add("cubrir");
            currentVerbList.Add("cuidar");
            currentVerbList.Add("cumplir");

            return currentVerbList;
        }
        public List<string> GetDVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("dar");
            currentVerbList.Add("deber");
            currentVerbList.Add("decidir");
            currentVerbList.Add("decir");
            currentVerbList.Add("dedicar");
            currentVerbList.Add("dejar");
            currentVerbList.Add("demorar");
            currentVerbList.Add("denunciar");
            currentVerbList.Add("deprimir");
            currentVerbList.Add("derribar");
            currentVerbList.Add("desarrollar");
            currentVerbList.Add("desayunar");
            currentVerbList.Add("desahogar");
            //currentVerbList.Add("deshogar");
            currentVerbList.Add("descansar");
            currentVerbList.Add("describir");
            currentVerbList.Add("descubrir");
            currentVerbList.Add("desear");
            currentVerbList.Add("deshacer");
            currentVerbList.Add("despedir");
            currentVerbList.Add("despertar");
            currentVerbList.Add("detener");
            currentVerbList.Add("detentar");
            currentVerbList.Add("dibujar");
            currentVerbList.Add("discutir");
            currentVerbList.Add("disfrutar");
            currentVerbList.Add("dividir");
            currentVerbList.Add("doler");
            currentVerbList.Add("donar");
            currentVerbList.Add("dormir");
            currentVerbList.Add("dudar");

            return currentVerbList;
        }
        public List<string> GetEVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("echar");
            currentVerbList.Add("elegir");
            currentVerbList.Add("enloquecer");
            currentVerbList.Add("egresar");
            currentVerbList.Add("empezar");
            currentVerbList.Add("empreder");
            currentVerbList.Add("encantar");
            currentVerbList.Add("encender");
            currentVerbList.Add("encontrar");
            currentVerbList.Add("enfermar");
            currentVerbList.Add("enojar");
            currentVerbList.Add("engañar");
            currentVerbList.Add("ensayar");
            currentVerbList.Add("entender");
            currentVerbList.Add("entrar");
            currentVerbList.Add("enviar");
            currentVerbList.Add("equivocar");
            currentVerbList.Add("escoger");
            currentVerbList.Add("esconder");
            currentVerbList.Add("escribir");
            currentVerbList.Add("escuchar");
            currentVerbList.Add("esculcar");
            currentVerbList.Add("esperar");
            currentVerbList.Add("estar");
            currentVerbList.Add("estilar");
            currentVerbList.Add("estilar");
            currentVerbList.Add("estrenar");
            currentVerbList.Add("estudiar");
            currentVerbList.Add("exigir");
            currentVerbList.Add("expedir");
            currentVerbList.Add("explicar");

            return currentVerbList;
        }
        public List<string> GetFVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("fallecer");
            currentVerbList.Add("faltar");
            currentVerbList.Add("fijar");
            currentVerbList.Add("fingir");
            currentVerbList.Add("firmar");
            currentVerbList.Add("fracasar");
            currentVerbList.Add("fregar");
            currentVerbList.Add("fumar");
            currentVerbList.Add("fugar");

            return currentVerbList;
        }
        public List<string> GetGVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("ganar");
            currentVerbList.Add("gastar");
            currentVerbList.Add("generar");
            currentVerbList.Add("girar");
            currentVerbList.Add("gozar");
            currentVerbList.Add("granizar");
            currentVerbList.Add("gritar");
            currentVerbList.Add("guardar");
            currentVerbList.Add("gustar");

            return currentVerbList;
        }
        public List<string> GetHVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("haber");
            currentVerbList.Add("hablar");
            currentVerbList.Add("hacer");
            currentVerbList.Add("herir");
            currentVerbList.Add("hervir");

            return currentVerbList;
        }
        public List<string> GetIVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("iniciar");
            currentVerbList.Add("insinuar");
            currentVerbList.Add("invertir");
            currentVerbList.Add("ir");

            return currentVerbList;
        }
        public List<string> GetJVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("jugar");
            currentVerbList.Add("jurar");

            return currentVerbList;
        }
        public List<string> GetLVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("lanzar");
            currentVerbList.Add("lastimar");
            currentVerbList.Add("lavar");
            currentVerbList.Add("leer");
            currentVerbList.Add("limpiar");
            currentVerbList.Add("llegar");
            currentVerbList.Add("llenar");
            currentVerbList.Add("llevar");
            currentVerbList.Add("lograr");
            currentVerbList.Add("luchar");

            return currentVerbList;
        }
        public List<string> GetMVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("maquillar");
            currentVerbList.Add("mandar");
            currentVerbList.Add("marcar");
            currentVerbList.Add("marchar");
            currentVerbList.Add("medir");
            currentVerbList.Add("mejorar");
            currentVerbList.Add("meter");
            currentVerbList.Add("mirar");
            currentVerbList.Add("molestar");
            currentVerbList.Add("morder");
            currentVerbList.Add("morir");
            currentVerbList.Add("mostrar");
            currentVerbList.Add("mover");
            currentVerbList.Add("mudar");

            return currentVerbList;
        }
        public List<string> GetNVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("nadar");
            currentVerbList.Add("necesitar");
            currentVerbList.Add("negar");

            return currentVerbList;
        }
        public List<string> GetOVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("obligar");
            currentVerbList.Add("obtener");
            currentVerbList.Add("ocultar");
            currentVerbList.Add("ofrecer");
            currentVerbList.Add("oir");
            currentVerbList.Add("oler");
            currentVerbList.Add("olvidar");
            currentVerbList.Add("omitir");
            currentVerbList.Add("organizar");
            currentVerbList.Add("otorgar");

            return currentVerbList;
        }
        public List<string> GetPVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("pagar");
            //currentVerbList.Add("pajeabar");
            currentVerbList.Add("parlar");
            currentVerbList.Add("parar");
            currentVerbList.Add("parecer");
            currentVerbList.Add("parir");
            currentVerbList.Add("partir");
            currentVerbList.Add("pasar");
            currentVerbList.Add("patinar");
            currentVerbList.Add("pedir");
            currentVerbList.Add("pegar");
            currentVerbList.Add("peinar");
            currentVerbList.Add("pensar");
            currentVerbList.Add("pesar");
            currentVerbList.Add("perder");
            currentVerbList.Add("permitir");
            currentVerbList.Add("pescar");
            currentVerbList.Add("platicar");
            currentVerbList.Add("poder");
            currentVerbList.Add("poseer");
            currentVerbList.Add("practicar");
            currentVerbList.Add("preferir");
            currentVerbList.Add("preguntar");
            currentVerbList.Add("preparar");
            currentVerbList.Add("prestar");
            currentVerbList.Add("presumir");
            currentVerbList.Add("pretender");
            currentVerbList.Add("prohibir");
            currentVerbList.Add("prometer");
            currentVerbList.Add("pronunciar");
            currentVerbList.Add("proponer");
            currentVerbList.Add("proteger");

            return currentVerbList;
        }
        public List<string> GetQVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("quedar");
            currentVerbList.Add("querer");
            currentVerbList.Add("quemar");
            currentVerbList.Add("quitar");

            return currentVerbList;
        }
        public List<string> GetRVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("realizar");
            currentVerbList.Add("recibir");
            currentVerbList.Add("recargar");
            currentVerbList.Add("recoger");
            currentVerbList.Add("reconocer");
            currentVerbList.Add("reconcilar");
            currentVerbList.Add("recordar");
            currentVerbList.Add("recorrer");
            currentVerbList.Add("regalar");
            currentVerbList.Add("regresar");
            currentVerbList.Add("rehacer");
            currentVerbList.Add("rendir");
            currentVerbList.Add("renovar");
            currentVerbList.Add("reparar");
            currentVerbList.Add("repartir");
            currentVerbList.Add("repetir");
            currentVerbList.Add("responder");
            currentVerbList.Add("resaltar");
            currentVerbList.Add("retrasar");
            currentVerbList.Add("rezar");
            currentVerbList.Add("rodear");
            currentVerbList.Add("rogar");
            currentVerbList.Add("romper");

            return currentVerbList;
        }
        public List<string> GetSVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("saber");
            currentVerbList.Add("salir");
            currentVerbList.Add("saludar");
            currentVerbList.Add("secar");
            currentVerbList.Add("seguir");
            currentVerbList.Add("sentar");
            currentVerbList.Add("sentir");
            currentVerbList.Add("ser");
            currentVerbList.Add("servir");
            currentVerbList.Add("soler");
            currentVerbList.Add("soportar");
            currentVerbList.Add("subir");
            currentVerbList.Add("sufrir");
            currentVerbList.Add("sugerir");
            currentVerbList.Add("sumar");
            currentVerbList.Add("superar");
            currentVerbList.Add("susurrar");

            return currentVerbList;
        }
        public List<string> GetTVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("tardar");
            currentVerbList.Add("temblar");
            currentVerbList.Add("temer");
            currentVerbList.Add("tener");
            currentVerbList.Add("terminar");
            currentVerbList.Add("tirar");
            currentVerbList.Add("tocar");
            currentVerbList.Add("tomar");
            currentVerbList.Add("toser");
            currentVerbList.Add("trabajar");
            currentVerbList.Add("traducir");
            currentVerbList.Add("traer");
            currentVerbList.Add("tratar");
            currentVerbList.Add("tumbar");

            return currentVerbList;
        }
        public List<string> GetUVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("unir");
            currentVerbList.Add("usar");
            currentVerbList.Add("utilizar");

            return currentVerbList;
        }
        public List<string> GetVVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("vender");
            currentVerbList.Add("venir");
            currentVerbList.Add("ver");
            currentVerbList.Add("vestir");
            currentVerbList.Add("viajar");
            currentVerbList.Add("visitar");
            currentVerbList.Add("vivir");
            currentVerbList.Add("volar");
            currentVerbList.Add("volver");

            return currentVerbList;
        }
        public List<string> GetZVerbList()
        {
            var currentVerbList = new List<string>();

            currentVerbList.Add("zarpar");

            return currentVerbList;
        }

        #endregion
    }
}
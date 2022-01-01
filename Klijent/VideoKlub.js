import { Clan } from "./Clan.js";
import { Disk } from "./Disk.js";
import { Film } from "./Film.js";
import { Glumac } from "./Glumac.js";
import { Reziser } from "./Reziser.js";

export class VideoKlub{
    constructor(){
        this.listaClanova=[];
        this.listaDiskova=[];
        this.listaFilmova=[];
        this.kontejner=null;
    }
    crtajVideoKlub(host){
        this.kontejner=document.createElement("div");
        this.kontejner.className="GlavniKontejner";
        host.appendChild(this.kontejner);
        this.crtajformu(this.kontejner);
    }
    crtajformu(host){
        if(!host)
            throw new Exception("Roditeljski element ne postoji");
        const kontForma = document.createElement("div");
        kontForma.className="kontForma";
        host.appendChild(kontForma);

        var elLabela = document.createElement("h3");
        elLabela.innerHTML="Clanovi";
        kontForma.appendChild(elLabela);

        elLabela = document.createElement("label");
        elLabela.innerHTML="Broj članske karte";
        kontForma.appendChild(elLabela);
        
        let tb= document.createElement("input");
        tb.className="unos_clanska_karta";
        kontForma.appendChild(tb);

        elLabela = document.createElement("label");
        elLabela.innerHTML="Ime";
        kontForma.appendChild(elLabela);
        
        tb= document.createElement("input");
        tb.className="unos_ime";
        kontForma.appendChild(tb);

        elLabela = document.createElement("label");
        elLabela.innerHTML="Prezime";
        kontForma.appendChild(elLabela);
        
        tb= document.createElement("input");
        tb.className="unos_prezime";
        kontForma.appendChild(tb);

        elLabela = document.createElement("label");
        elLabela.innerHTML="Datum isteka clanarine";
        kontForma.appendChild(elLabela);
        
        tb= document.createElement("input");
        tb.className="unos_datuma_isteka_clanarine";
        tb.type="date";
        kontForma.appendChild(tb);

        let dugme1 = document.createElement("button");
        dugme1.innerHTML="Dodaj člana";
        dugme1.onclick = (ev)=>{
            this.dodajClana();
        }
        kontForma.appendChild(dugme1);

        let dugme2 = document.createElement("button");
        dugme2.innerHTML="Promeni člana";
        dugme2.onclick = (ev)=>{
            this.promeniClana();
        }
        kontForma.appendChild(dugme2);

        let dugme3 = document.createElement("button");
        dugme3.innerHTML="Izbriši člana";
        dugme3.onclick = (ev)=>{
            this.izbrisiClana();
        }
        kontForma.appendChild(dugme3);

        let dugme4 = document.createElement("button");
        dugme4.innerHTML="Prikaži člana";
        dugme4.onclick = (ev)=>{
            this.prikaziClana();
        }
        kontForma.appendChild(dugme4);

        elLabela = document.createElement("h3");
        elLabela.innerHTML="Diskovi";
        kontForma.appendChild(elLabela);

        elLabela = document.createElement("label");
        elLabela.innerHTML="Film na disku";
        kontForma.appendChild(elLabela);
        
        tb= document.createElement("input");
        tb.className="unos_filma_na_disku";
        kontForma.appendChild(tb);

        elLabela = document.createElement("label");
        elLabela.innerHTML="Datum izdavanja diska";
        kontForma.appendChild(elLabela);
        
        tb= document.createElement("input");
        tb.className="unos_datuma_izdavanja_diska";
        tb.type="date";
        kontForma.appendChild(tb);

        elLabela = document.createElement("label");
        elLabela.innerHTML="Datum vraćanja diska";
        tb.type="date";
        kontForma.appendChild(elLabela);
        
        tb= document.createElement("input");
        tb.className="unos_datuma_vracanja_diska";
        tb.type="date";
        kontForma.appendChild(tb);

        let dugme5 = document.createElement("button");
        dugme5.innerHTML="Pozajmi disk";
        dugme5.onclick = (ev)=>{
            this.pozajmiDisk();
        }
        kontForma.appendChild(dugme5);

        let dugme6 = document.createElement("button");
        dugme6.innerHTML="Vrati disk";
        dugme6.onclick = (ev)=>{
            this.vratiDisk();
        }
        kontForma.appendChild(dugme6);

        let dugme11 = document.createElement("button");
        dugme11.innerHTML="Prikaži broj diskova sa datim filmom";
        dugme11.onclick = (ev)=>{
            this.brojDiskova();
        }
        kontForma.appendChild(dugme11);

        let dugme10 = document.createElement("button");
        dugme10.innerHTML="Prikaži diskove koje je član pozajmio";
        dugme10.onclick = (ev)=>{
            this.prikaziPozajmljeneDiskove();
        }
        kontForma.appendChild(dugme10);

        let dugme7 = document.createElement("button");
        dugme7.innerHTML="Prikaži podatke o filmu";
        dugme7.onclick = (ev)=>{
            this.prikaziFilm();
        }
        kontForma.appendChild(dugme7);

        let dugme8 = document.createElement("button");
        dugme8.innerHTML="Prikaži podatke o režiseru";
        dugme8.onclick = (ev)=>{
            this.prikaziRezisera();
        }
        kontForma.appendChild(dugme8);

        let dugme9 = document.createElement("button");
        dugme9.innerHTML="Prikaži podatke o glumcu";
        dugme9.onclick = (ev)=>{
            this.prikaziGlumca();
        }
        kontForma.appendChild(dugme9);
    }
    prikazClanaTabelarno(host){
        let prikazClana=document.createElement("div");
        prikazClana.className="PrikazClana";
        host.appendChild(prikazClana);

        var tabela=document.createElement("table");
        tabela.className="ClanTabela";
        prikazClana.appendChild(tabela);

        var tabelahead=document.createElement("thead");
        tabela.appendChild(tabelahead);

        var tr=document.createElement("tr");
        tabelahead.appendChild(tr);

        var tabelabody=document.createElement("tbody")
        tabelabody.className="PodacioClanu";
        tabela.appendChild(tabelabody);

        let th;
        var zag=["Broj clanske karte","Ime","Prezime","Datum isteka clanarine"];
        zag.forEach(el=>{
            th=document.createElement("th");
            th.innerHTML=el;
            tr.appendChild(th);
        })
    }
    prikazFilmaTabelarno(host){
        let prikazFilma=document.createElement("div");
        prikazFilma.className="PrikazFilma";
        host.appendChild(prikazFilma);

        var tabela=document.createElement("table");
        tabela.className="FilmTabela";
        prikazFilma.appendChild(tabela);

        var tabelahead=document.createElement("thead");
        tabela.appendChild(tabelahead);

        var tr=document.createElement("tr");
        tabelahead.appendChild(tr);

        var tabelabody=document.createElement("tbody")
        tabelabody.className="PodacioFilmu";
        tabela.appendChild(tabelabody);

        let th;
        var zag=["Naslov","Tip","Rejting","Godina","Nominacija za nagrade","Dobijene nagrade"];
        zag.forEach(el=>{
            th=document.createElement("th");
            th.innerHTML=el;
            th.className="zaglavlje";
            tr.appendChild(th);
    })
}
prikazReziseraTabelarno(host){
    let prikazRezisera=document.createElement("div");
    prikazRezisera.className="PrikazRezisera";
    host.appendChild(prikazRezisera);

    var tabela=document.createElement("table");
    tabela.className="ReziserTabela";
    prikazRezisera.appendChild(tabela);

    var tabelahead=document.createElement("thead");
    tabela.appendChild(tabelahead);

    var tr=document.createElement("tr");
    tabelahead.appendChild(tr);

    var tabelabody=document.createElement("tbody")
    tabelabody.className="PodacioReziseru";
    tabela.appendChild(tabelabody);

    let th;
    var zag=["Ime","Prezime","Datum rođenja","Mesto rođenja"];
    zag.forEach(el=>{
        th=document.createElement("th");
        th.innerHTML=el;
        tr.appendChild(th);
    })
}
prikazGlumcaTabelarno(host){
    let prikazGlumca=document.createElement("div");
    prikazGlumca.className="PrikazGlumca";
    host.appendChild(prikazGlumca);

    var tabela=document.createElement("table");
    tabela.className="GlumacTabela";
    prikazGlumca.appendChild(tabela);

    var tabelahead=document.createElement("thead");
    tabela.appendChild(tabelahead);

    var tr=document.createElement("tr");
    tabelahead.appendChild(tr);

    var tabelabody=document.createElement("tbody")
    tabelabody.className="PodacioGlumcu";
    tabela.appendChild(tabelabody);

    let th;
    var zag=["Ime","Prezime","Datum rođenja","Mesto rođenja"];
    zag.forEach(el=>{
        th=document.createElement("th");
        th.innerHTML=el;
        tr.appendChild(th);
    })
}
prikazDiskovaTabelarno(host){
    let prikazDiska=document.createElement("div");
    prikazDiska.className="PrikazDiska";
    host.appendChild(prikazDiska);

    var tabela=document.createElement("table");
    tabela.className="DiskTabela";
    prikazDiska.appendChild(tabela);

    var tabelahead=document.createElement("thead");
    tabela.appendChild(tabelahead);

    var tr=document.createElement("tr");
    tabelahead.appendChild(tr);

    var tabelabody=document.createElement("tbody")
    tabelabody.className="PodacioDisku";
    tabela.appendChild(tabelabody);

    let th;
    var zag=["Film na disku","Datum pozajmljivanja","Datum vraćanja"];
    zag.forEach(el=>{
        th=document.createElement("th");
        th.innerHTML=el;
        tr.appendChild(th);
    })
}
        prikaziClana(){
            var Broj_clanske_karte=document.querySelector(".unos_clanska_karta").value;
            if(Broj_clanske_karte==null || Broj_clanske_karte=="" || Broj_clanske_karte==undefined)
            alert("Nije unet broj članske karte");
                this.prikazClanaTabelarno(this.kontejner);
                fetch("https://localhost:5001/Clan/PreuzmiClana/"+Broj_clanske_karte,{
                    method:"GET"
                }).then(s=>{
                    if(s.ok){
                        s.json().then(data=>{
                            var telotabele=document.querySelector(".PodacioClanu");
                            
                                let clan=new Clan(data.broj_clanske_karte,data.ime,data.prezime,data.datum_isteka_clanarine);
                                clan.crtajClana(telotabele);
                            
                            
                        })
                    }
                    else alert("Greška");
                })
            
            
            let dugme = document.createElement("button");
            dugme.innerHTML="Zatvori";
            dugme.onclick = (ev)=>{
            let a=document.querySelector(".PrikazClana");
            this.kontejner.removeChild(a);
        }
        let a=document.querySelector(".PrikazClana");
        a.appendChild(dugme);
        }
        prikaziFilm(){
            var F=document.querySelector(".unos_filma_na_disku").value;
            if(F==null || F=="" || F==undefined)
            alert("Nije unet film koji je na disku");
                this.prikazFilmaTabelarno(this.kontejner);
                fetch("https://localhost:5001/Film/Filmovi_naslov/"+F,{
                    method:"GET"
                }).then(s=>{
                    if(s.ok){
                        s.json().then(data=>{
                            var telotabelefilma=document.querySelector(".PodacioFilmu");
                                   data.forEach(s=>{
                                       let film=new Film(s.naslov,s.tip,s.rejting,s.godina,s.nominacija_za_nagrade,s.dobijene_nagrade);
                                    film.crtajFilm(telotabelefilma);
                                   })
                                    
                                
                            })
                    }
                    else alert("Greška");
                })
                
            
            let dugme = document.createElement("button");
            dugme.innerHTML="Zatvori";
            dugme.onclick = (ev)=>{
            let a=document.querySelector(".PrikazFilma");
            this.kontejner.removeChild(a);
        }
        let a=document.querySelector(".PrikazFilma");
        a.appendChild(dugme);
        
        }
        prikaziRezisera(){
            var Film=document.querySelector(".unos_filma_na_disku").value;
            if(Film==null || Film=="" || Film==undefined)
            alert("Nije unet film koji je na disku");
                this.prikazReziseraTabelarno(this.kontejner);
                fetch("https://localhost:5001/Reziser/PreuzmiRezisera/"+Film,{
                    method:"GET"
                }).then(s=>{
                    if(s.ok){
                        s.json().then(data=>{
                            var telotabelerezisera=document.querySelector(".PodacioReziseru");
                                data.forEach(s=>{
                                    let reziser=new Reziser(s.ime,s.prezime,s.datum_rodjenja,s.mesto_rodjenja);
                                    reziser.crtajRezisera(telotabelerezisera);
                                })
                            })
                    }
                    else alert("Greška");
                })
                
            
            let dugme = document.createElement("button");
            dugme.innerHTML="Zatvori";
            dugme.onclick = (ev)=>{
            let a=document.querySelector(".PrikazRezisera");
            this.kontejner.removeChild(a);
        }
        let a=document.querySelector(".PrikazRezisera");
        a.appendChild(dugme);
        
        }
        prikaziGlumca(){
            var Film=document.querySelector(".unos_filma_na_disku").value;
            if(Film==null || Film=="" || Film==undefined)
            alert("Nije unet film koji je na disku");
                this.prikazGlumcaTabelarno(this.kontejner);
                fetch("https://localhost:5001/Glumac/PreuzmiGlumca/"+Film,{
                    method:"GET"
                }).then(s=>{
                    if(s.ok){
                        s.json().then(data=>{
                            var telotabeleglumca=document.querySelector(".PodacioGlumcu");
                                data.forEach(s=>{
                                    let glumac=new Glumac(s.ime,s.prezime,s.datum_rodjenja,s.mesto_rodjenja);
                                    glumac.crtajGlumca(telotabeleglumca);
                                })
                            })
                    }
                    else alert("Greška");
                })
                
            
            let dugme = document.createElement("button");
            dugme.innerHTML="Zatvori";
            dugme.onclick = (ev)=>{
            let a=document.querySelector(".PrikazGlumca");
            this.kontejner.removeChild(a);
        }
        let a=document.querySelector(".PrikazGlumca");
        a.appendChild(dugme);
        
        }
        prikaziPozajmljeneDiskove(){
            var Broj_clanske_karte=document.querySelector(".unos_clanska_karta").value;
            if(Broj_clanske_karte==null || Broj_clanske_karte=="" || Broj_clanske_karte==undefined)
            alert("Nije unet broj članske karte");
                this.prikazDiskovaTabelarno(this.kontejner);
                fetch("https://localhost:5001/Clan/VratiDiskovePozajmljene/"+Broj_clanske_karte,{
                    method:"GET"
                }).then(s=>{
                    if(s.ok){
                        s.json().then(data=>{
                            
                            var telotabelediska=document.querySelector(".PodacioDisku");
                           data.forEach(s=>{
                            let disk=new Disk(s.film,s.datum_iznajmljivanja_diska,s.datum_vracanja_diska);
                           disk.crtajDisk(telotabelediska);
                               
                           })
                           
                            
                            
                        })
                    }
                    else alert("Greška");
                })
            
            let dugme = document.createElement("button");
            dugme.innerHTML="Zatvori";
            dugme.onclick = (ev)=>{
            let a=document.querySelector(".PrikazDiska");
            this.kontejner.removeChild(a);
        }
        let a=document.querySelector(".PrikazDiska");
        a.appendChild(dugme);
        }
        pozajmiDisk(){
            var Film=document.querySelector(".unos_filma_na_disku").value;
            var Broj_clanske_karte=document.querySelector(".unos_clanska_karta").value;
            var Datum_iznajmljivanja_diska=document.querySelector(".unos_datuma_izdavanja_diska").value;
            var Datum_vracanja_diska=document.querySelector(".unos_datuma_vracanja_diska").value;
            if(Film==null || Film=="" || Film==undefined)
            alert("Nije unet film koji je na disku");
            if(Broj_clanske_karte==null || Broj_clanske_karte=="" || Broj_clanske_karte==undefined)
            alert("Nije unet broj članske karte");
            if(Datum_iznajmljivanja_diska==null || Datum_iznajmljivanja_diska=="" || Datum_iznajmljivanja_diska==undefined)
            alert("Nije unet datum iznajmljivanja diska");
            if(Datum_vracanja_diska==null || Datum_vracanja_diska=="" || Datum_vracanja_diska==undefined)
            alert("Nije unet datum vraćanja diska");
            fetch("https://localhost:5001/Disk/Pozajmidisk/"+Film+"/"+Broj_clanske_karte+"/"+Datum_iznajmljivanja_diska+"/"+Datum_vracanja_diska,
            {
                method:"PUT",
                headers:{
                    "Content-Type":"application/json"
                },
               
    
            }).then(s=>{
                if(s.ok){
                      alert("Član je uspešno pozajmio disk");
                }
                else alert("Dodeljivanje diska nije uspelo");
            })
        }
        vratiDisk(){
            var Film=document.querySelector(".unos_filma_na_disku").value;
            var Broj_clanske_karte=document.querySelector(".unos_clanska_karta").value;
            if(Film==null || Film=="" || Film==undefined)
            alert("Nije unet film koji je na disku");
            if(Broj_clanske_karte==null || Broj_clanske_karte=="" || Broj_clanske_karte==undefined)
            alert("Nije unet broj članske karte");
            fetch("https://localhost:5001/Disk/Vratidisk/"+Film+"/"+Broj_clanske_karte,
            {
                method:"PUT",
                headers:{
                    "Content-Type":"application/json"
                },
               
    
            }).then(s=>{
                if(s.ok){
                      alert("Član je uspešno vratio disk");
                }
                else alert("Vraćanje diska nije uspelo");
            })
        }
        dodajClana(){
            var Broj_clanske_karte=document.querySelector(".unos_clanska_karta").value;
            var Ime=document.querySelector(".unos_ime").value;
            var Prezime=document.querySelector(".unos_prezime").value;
            var Datum_isteka_clanarine=document.querySelector(".unos_datuma_isteka_clanarine").value;
            if(Broj_clanske_karte==null || Broj_clanske_karte=="" || Broj_clanske_karte==undefined)
            alert("Nije unet Broj članske karte");
            if(Ime==null || Ime=="" || Ime==undefined)
            alert("Nije uneto ime člana");
            if(Prezime==null || Prezime=="" || Prezime==undefined)
            alert("Nije uneto prezime člana");
            if(Datum_isteka_clanarine==null || Datum_isteka_clanarine=="" || Datum_isteka_clanarine==undefined)
            alert("Nije unet datum isteka članarine");
            var clan=new Clan(Broj_clanske_karte,Ime,Prezime,Datum_isteka_clanarine);
            fetch("https://localhost:5001/Clan/DodatiClana",
            {
                method:"POST",
                headers:{
                    "Content-Type":"application/json"
                },
                body:JSON.stringify(clan)
    
            }).then(s=>{
                if(s.ok){
                      this.prikaziClana();
                }
                else alert("Greška");
            })
        }
        promeniClana(){
            var Broj_clanske_karte=document.querySelector(".unos_clanska_karta").value;
            var Ime=document.querySelector(".unos_ime").value;
            var Prezime=document.querySelector(".unos_prezime").value;
            var Datum_isteka_clanarine=document.querySelector(".unos_datuma_isteka_clanarine").value;
            if(Broj_clanske_karte==null || Broj_clanske_karte=="" || Broj_clanske_karte==undefined)
            alert("Nije unet broj članske karte");
            var clan=new Clan(Broj_clanske_karte,Ime,Prezime,Datum_isteka_clanarine);
            fetch("https://localhost:5001/Clan/PromenaClana",
            {
                method:"PUT",
                headers:{
                    "Content-Type":"application/json"
                },
                body:JSON.stringify(clan)
    
            }).then(s=>{
                if(s.ok){
                    this.izbrisiClana();
                    this.prikaziClana();
                }
                else alert("Greška");
            })
        }
        izbrisiClana(){
            var Broj_clanske_karte=document.querySelector(".unos_clanska_karta").value;
            if(Broj_clanske_karte==null || Broj_clanske_karte=="" || Broj_clanske_karte==undefined)
            alert("Nije unet broj članske karte");
            fetch("https://localhost:5001/Clan/IzbrisatiClana/"+Broj_clanske_karte,
            {
                method:"DELETE",
                headers:{
                    "Content-Type":"application/json"
                },
                
    
            }).then(s=>{
                if(s.ok){
                     alert("Baza podataka je ušpešno ažurirana")
                }
                else alert("Greška");
            })
        }
        brojDiskova(){
            var Film=document.querySelector(".unos_filma_na_disku").value;
            if(Film==null || Film=="" || Film==undefined)
            alert("Nije unet film koji je na disku");
            fetch("https://localhost:5001/Disk/PreuzmiBrojDiskova/"+Film,{
                    method:"GET"
                }).then(s=>{
                    if(s.ok){
                        s.json().then(data=>{
                              alert("Broj diskova sa ovim filmom je: "+data.broj_diskova);
                            })
                    }
                    else alert("Greška");
                })
        }

}
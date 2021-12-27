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
        elLabela.innerHTML="Broj clanske karte";
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
        dugme1.innerHTML="Dodaj clana";
        dugme1.onclick = (ev)=>{
            this.dodajClana();
        }
        kontForma.appendChild(dugme1);

        let dugme2 = document.createElement("button");
        dugme2.innerHTML="Promeni clana";
        dugme2.onclick = (ev)=>{
            this.promeniClana();
        }
        kontForma.appendChild(dugme2);

        let dugme3 = document.createElement("button");
        dugme3.innerHTML="Izbrisi clana";
        dugme3.onclick = (ev)=>{
            this.izbrisiClana();
        }
        kontForma.appendChild(dugme3);

        let dugme4 = document.createElement("button");
        dugme4.innerHTML="Prikazi clana";
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
        elLabela.innerHTML="Datum vracanja diska";
        tb.type="date";
        kontForma.appendChild(elLabela);
        
        tb= document.createElement("input");
        tb.className="unos_datuma_vracanja_diska";
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

        let dugme10 = document.createElement("button");
        dugme10.innerHTML="Prikazi diskove koje je clan pozajmio";
        dugme10.onclick = (ev)=>{
            this.prikaziPozajmljeneDiskove();
        }
        kontForma.appendChild(dugme10);

        let dugme7 = document.createElement("button");
        dugme7.innerHTML="Prikazi podatke o filmu";
        dugme7.onclick = (ev)=>{
            this.prikaziFilm();
        }
        kontForma.appendChild(dugme7);

        let dugme8 = document.createElement("button");
        dugme8.innerHTML="Prikazi podatke o reziseru";
        dugme8.onclick = (ev)=>{
            this.prikaziRezisera();
        }
        kontForma.appendChild(dugme8);

        let dugme9 = document.createElement("button");
        dugme9.innerHTML="Prikazi podatke o glumcu";
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
    var zag=["Ime","Prezime","Datum rodjenja","Mesto rodjenja"];
    zag.forEach(el=>{
        th=document.createElement("th");
        th.innerHTML=el;
        tr.appendChild(th);
    })
}
prikazGlumcaTabelarno(host){
    let prikazGlumca=document.createElement("div");
    prikazGlumca.className="PrikazRezisera";
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
    var zag=["Ime","Prezime","Datum rodjenja","Mesto rodjenja"];
    zag.forEach(el=>{
        th=document.createElement("th");
        th.innerHTML=el;
        tr.appendChild(th);
    })
}
        prikaziClana(){
            var Broj_clanske_karte=document.querySelector(".unos_clanska_karta").value;
            if(Broj_clanske_karte!=null)
            {
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
                })
            }
            else
            alert("Nije unet Broj clanske karte");
        }
        prikaziFilm(){
            var Naslov=document.querySelector(".unos_filma_na_disku").value;
            if(Naslov!=null)
            {
                this.prikazFilmaTabelarno(this.kontejner);
                fetch("https://localhost:5001/Film/Filmovi_naslov/"+Naslov,{
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
                })
                
            }
            else
            alert("Nije unet naziv filma");
        
        }
        prikaziRezisera(){
            var Naslov=document.querySelector(".unos_filma_na_disku").value;
            if(Naslov!=null)
            {
                this.prikazReziseraTabelarno(this.kontejner);
                fetch("https://localhost:5001/Reziser/PreuzmiRezisera/"+Naslov,{
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
                })
                
            }
            else
            alert("Nije unet naziv filma");
        
        }
        prikaziGlumca(){
            var Naslov=document.querySelector(".unos_filma_na_disku").value;
            if(Naslov!=null)
            {
                this.prikazGlumcaTabelarno(this.kontejner);
                fetch("https://localhost:5001/Glumac/PreuzmiGlumca/"+Naslov,{
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
                })
                
            }
            else
            alert("Nije unet naziv filma");
        
        }
        prikaziPozajmljeneDiskove(){
            var Broj_clanske_karte=document.querySelector(".unos_clanska_karta").value;
            if(Broj_clanske_karte!=null)
            {
                
                fetch("https://localhost:5001/Clan/VratiDiskovePozajmljene/"+Broj_clanske_karte,{
                    method:"GET"
                }).then(s=>{
                    if(s.ok){
                        s.json().then(data=>{
                            
                            
                            data.forEach(s=>{
                                let disk=new Disk(s.film_na_disku,s.datum_pozajmljivanja,s.datum_vracanja);
                                disk.crtajDisk(this.kontejner);
                            })
                            
                            
                        })
                    }
                })
            }
            else
            alert("Nije unet Broj clanske karte");
        }
}
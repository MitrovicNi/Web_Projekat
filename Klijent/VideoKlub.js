import { Clan } from "./Clan.js";

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
        kontForma.appendChild(tb);

        elLabela = document.createElement("label");
        elLabela.innerHTML="Datum vracanja diska";
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

        let dugme7 = document.createElement("button");
        dugme7.innerHTML="Prikazi podatke o filmu";
        dugme7.onclick = (ev)=>{
            this.prikaziFilm();
        }
        kontForma.appendChild(dugme7);
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
        prikaziClana(){
            var Broj_clanske_karte=document.getElementsByClassName(".unos_clanska_karta").value;
            if(Broj_clanske_karte!=null)
            {
                this.prikazClanaTabelarno(this.kontejner);
                fetch("https://localhost:5001/Clan/PreuzmiClana/"+Broj_clanske_karte,{
                    method:"GET"
                }).then(s=>{
                    if(s.ok){
                        s.json().then(data=>{
                            var telotabele=document.querySelector(".PodacioClanu");
                            data.forEach(s=>{
                                let clan=new Clan(s.broj_clanske_karte,s.ime,s.prezime,s.datum_isteka_clanarine);
                                clan.crtajClana(telotabele);
                            })
                            
                        })
                    }
                })
            }
            else
            alert("Nije unet Broj clanske karte");
        }
}
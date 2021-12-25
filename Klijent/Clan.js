export class Clan{
    constructor(broj_clanske_karte,ime,prezime,datum_isteka_clanarine){
        this.broj_clanske_karte=broj_clanske_karte;
        this.ime=ime;
        this.prezime=prezime;
        this.datum_isteka_clanarine=datum_isteka_clanarine;
        this.kontejner=null;
    }
    crtajClana(host){
        var tr= document.createElement("tr");
        host.appendChild(tr);

        var el=document.createElement("td");
        el.innerHTML=this.broj_clanske_karte;
        tr.appendChild(el);
        el=document.createElement("td");
        el.innerHTML=this.ime;
        tr.appendChild(el);
        el=document.createElement("td");
        el.innerHTML=this.prezime;
        tr.appendChild(el);
        el=document.createElement("td");
        el.innerHTML=this.datum_isteka_clanarine;
        tr.appendChild(el);
    }
}
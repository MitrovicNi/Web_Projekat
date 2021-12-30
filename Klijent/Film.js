export class Film{
    constructor(naslov,tip,rejting,godina,nominacija_za_nagrade,dobijene_nagrade){
        this.naslov=naslov;
        this.tip=tip;
        this.rejting=rejting;
        this.godina=godina;
        this.nominacija_za_nagrade=nominacija_za_nagrade;
        this.dobijene_nagrade=dobijene_nagrade;
        this.kontejner=null;
    }
    crtajFilm(host){
        var tr= document.createElement("tr");
        host.appendChild(tr);

        var el=document.createElement("td");
        el.innerHTML=this.naslov;
        tr.appendChild(el);
        el=document.createElement("td");
        el.innerHTML=this.tip;
        tr.appendChild(el);
        el=document.createElement("td");
        el.innerHTML=this.rejting;
        tr.appendChild(el);
        el=document.createElement("td");
        el.innerHTML=this.godina;
        tr.appendChild(el);
        el=document.createElement("td");
        el.innerHTML=this.nominacija_za_nagrade;
        tr.appendChild(el);
        el=document.createElement("td");
        el.innerHTML=this.dobijene_nagrade;
        tr.appendChild(el);
    }
}
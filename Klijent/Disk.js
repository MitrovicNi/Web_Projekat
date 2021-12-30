export class Disk{
    constructor(film_na_disku,datum_pozajmljivanja,datum_vracanja)
    {
        this.film_na_disku=film_na_disku;
        this.datum_pozajmljivanja=datum_pozajmljivanja;
        this.datum_vracanja=datum_vracanja;
        this.kontejner=null;
    }
    crtajDisk(host){
        var tr= document.createElement("tr");
        host.appendChild(tr);

        var el=document.createElement("td");
        el.innerHTML=this.film_na_disku;
        tr.appendChild(el);
        el=document.createElement("td");
        el.innerHTML=this.datum_pozajmljivanja;
        tr.appendChild(el);
        el=document.createElement("td");
        el.innerHTML=this.datum_vracanja;
        tr.appendChild(el);
    }
}
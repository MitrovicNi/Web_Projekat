export class Disk{
    constructor(film_na_disku,datum_pozajmljivanja,datum_vracanja)
    {
        this.film_na_disku=film_na_disku;
        this.datum_pozajmljivanja=datum_pozajmljivanja;
        this.datum_vracanja=datum_vracanja;
        this.kontejner=null;
    }
    crtajDisk(host){
        this.kontejner = document.createElement("div");
        this.kontejner.className = "lok";
        var lab1=document.createElement("label");
        lab1.innerHTML="Film na disku:"+this.film_na_disku;
        lab1.appendChild(this.kontejner);
        var lab2=document.createElement("label");
        lab2.innerHTML="Datum pozajmljivanja:"+this.datum_pozajmljivanja;
        lab2.appendChild(this.kontejner);
        var lab3=document.createElement("label");
        lab3.innerHTML="Datum vracanja:"+this.datum_vracanja;
        lab3.appendChild(this.kontejner);
        host.appendChild(this.kontejner);
    }
}
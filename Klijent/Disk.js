export class Disk{
    constructor(film_na_diku,broj_diskova,datum_pozajmljivanja,datum_vracanja)
    {
        this.film_na_diku=film_na_diku;
        this.broj_diskova=broj_diskova;
        this.datum_pozajmljivanja=datum_pozajmljivanja;
        this.datum_vracanja=datum_vracanja;
        this.kontejner=null;
    }
    crtajDisk(host){
        var tr= document.createElement("tr");
         host.appendChild(tr);
 
         
         var el=document.createElement("td");
         el.innerHTML=this.film_na_diku;
         tr.appendChild(el);
         el=document.createElement("td");
         el.innerHTML=this.broj_diskova;
         tr.appendChild(el);
         el=document.createElement("td");
         el.innerHTML=this.datum_pozajmljivanja;
         tr.appendChild(el);
         el=document.createElement("td");
         el.innerHTML=this.datum_vracanja;
         tr.appendChild(el);
     
 }
}
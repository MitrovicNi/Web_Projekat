export class Reziser{
    constructor(ime,prezime,datum_rodjenja,mesto_rodjenja){
        this.ime=ime;
        this.prezime=prezime;
        this.datum_rodjenja=datum_rodjenja;
        this.mesto_rodjenja=mesto_rodjenja;
        this.kontejner=null;
    }
    crtajRezisera(host){
           var tr= document.createElement("tr");
            host.appendChild(tr);
    
            
            var el=document.createElement("td");
            el.innerHTML=this.ime;
            tr.appendChild(el);
            el=document.createElement("td");
            el.innerHTML=this.prezime;
            tr.appendChild(el);
            el=document.createElement("td");
            el.innerHTML=this.datum_rodjenja;
            tr.appendChild(el);
            el=document.createElement("td");
            el.innerHTML=this.mesto_rodjenja;
            tr.appendChild(el);
        
    }
}
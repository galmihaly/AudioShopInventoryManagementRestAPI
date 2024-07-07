<div align="center">
    <img src="ReadmeImages/project_readme_banner_1500X450.png" alt="AudioShop Logo">
</div>

<div align="center">
    <h1 style="border-bottom: 0">AudioShop Inventory Management</h1>
    <h3>Rest API (Backend)</h3>
    <h4>Portf�li� munka</h4>
    <br>
</div>

---

<div>
    <h3>A projekt le�r�sa:</h3>
</div>

- Az AudioShopInventoryManagement mobil applik�ci� backend r�sz�t val�s�tja meg, ez a program fogja szolg�ltatni az adatokat az alkalmaz�sunk sz�m�ra.
- A program <b>Asp.NET (C#)</b> alapon lett elk�sz�tve.

---

<div>
    <h3>A projekthez felhaszn�lt, C# alap� f�bb oszt�lyok, csomagok:</h3>
</div>

- Framework: .NET 8. Verzi�
- Adatb�zis kezel�s: Entity Framework �s Microsoft SQLServer
- JWT (JSON Web Token) kezel�se: JwtBearer (Microsoft saj�t csomagja)
- API k�r�sek �s v�laszok kezel�se: Newtonsoft

---

<div align="center">
    <br>
    <h3>Az adatb�zis fel�p�t�se</h3>
</div>

<div align="center">
        <a href="https://github.com/galmihaly/AudioShopInventoryManagementRestAPI/blob/master/ReadmeImages/database.png"><img src="ReadmeImages/database.png" alt="AudioShop"></a>
        <p>Az adatb�zis t�bl�i �s az azok k�zti kapcsolatok</p>
</div>

---

<div align="center">
    <br>
    <h3>A term�k azonos�t�j�nak kezel�se</h3>
</div>

- A term�kek azonos�t�ja a backend oldalon 3 k�l�n r�sz szerint van kezelve:
    - Brand ID -> az adott eszk�z m�rk�j�nak a megnevez�se
    - Category ID -> az adott term�k kateg�ri�ja
    - Model ID -> az adott term�k model megnevez�se, sz�ma
- A term�k azonos�t�ja egy p�lda term�k eset�n (Sennheiser HD 560S):
    - Ebben az esetben a <b>Sennheiser</b> lesz a m�rka
    - A <b>fejhallgat�</b> kateg�ri�ba sorolhat�.
    - Model megnev�zese (sz�ma) pedig a <b>HD 560S</b> lesz.
- Az azonos�t� ilyen m�don val� kezel�se megengedi azt a lehet�s�get, hogy egyes m�rk�j�, kateg�ri�j� �s modell� eszk�z�ket meg tudjunk k�l�nb�ztetni egym�st�l.
- Ha p�ld�ul egy megl�v� modelb�l a gy�rt� k�s�bb l�trehoz egy speci�lis v�ltoztatot, akkor azt k�nnyen tudjuk ezzel a m�dszerrel kezelni backend oldalon.
- A m�rka, kateg�ria �s model mindegyike rendelkezik egy egyedi azonos�t�val, amelyekb�l a term�k felv�telekor l�trehozzuk a term�k f�azonos�t�j�t.
- <b>Ez az azonos�t� nem �sszekeverend� a vonalk�ddal:</b>
    - A vonalk�d <b>(adatb�zisban Products t�bla Barcode mez�)</b> minden egyes term�ket k�l�n-k�l�n, egyedileg azonos�t <b>(nincs k�t ugyanolyan vonalk�ddal rendelkez� term�k az adatb�zisban).</b>
    - Ezzel szemben a term�k azonos�t� <b>(adatb�zisban Products t�bla ProductsId mez�)</b> a term�ket l�trehoz� c�get, kateg�ria besorol�s�t �s a c�g �ltal a term�k l�trehoz�sakor meghat�rozott model nev�t �rja le <b>(az adatb�zisban t�bb el�fordul�s lehets�ges)</b>.
- <b>A val�s�gban elt�rhet a term�k azons�t�j�nak kezel�se.</b>
<br>

<div align="center">
        <img src="ReadmeImages/product_id.png" alt="AudioShop"></a>
        <p>A term�k azonos�t�j�nak r�szei</p>
</div>

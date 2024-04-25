# Konwerter Markdown na LaTeX

Projekt zaliczeniowy z przedmiotu Teoria Kompilacji i Kompilatory autorstwa Artur Sojka i Piotr Waluszek.

Konwerter pisany jest w języku C# i jako generatora parsera używa programu ANTLRv4.

## Format wejściowy

Wejściem do programu jest plik Markdown o zredukowanej składni.

Każdy program parsujący/renderujący Markdowna działa trochę inaczej, gdyż format ten nie ma jednej specyfikacji.
Nasz konwerter bazuje głównie na specyfikacji [CommonMark](https://spec.commonmark.org/0.31.2/) oraz, w mniejszym stopniu, programu [Pandoc](https://pandoc.org/MANUAL.html#pandocs-markdown).

Ograniczyliśmy skłandnię do następujących struktur, które nie mogą być w sobie zagnieżdżane:
- Nagłówki (tylko te rozpoczynające się od `#`)
- Linie poziome
- paragrafy tekstu
- listy numerowane i nienumerowane (z najwyżej trzypoziomowym zagnieżdżaniem, elementy nie są kontynuowane w następnej linii)
- wcięte bloki kodu
- odgrodzone bloki kodu (oznaczone przez dokładnie 3 `` ` `` lub `~` i zawsze poprawnie zamknięte) 
- Cytaty blokowe (nie są kontynuowane w następnej linii, jeśli nie rozpoczyna się znakiem `>`)
- obrazy (tylko lokalne pliki)
- Tabele

W samym tekście stylizowane są na razie tylko linki do stron internetowych.

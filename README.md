
# Konwerter Markdown na LaTeX

Projekt zaliczeniowy z przedmiotu Teoria Kompilacji i Kompilatory autorstwa Artura Sojki i Piotra Waluszka.

Konwerter pisany jest w języku C# i jako generatora parsera używa programu ANTLRv4.

## Narzędzia i technologie

- **[ANTLRv4](https://www.antlr.org/)**: Narzędzie do generowania parserów, które umożliwia analizę składniową kodu źródłowego. Wykorzystujemy ANTLR do definiowania gramatyki, z której generujemy klasy parserów w C#. Jest idealne do precyzyjnej analizy tekstu, niezbędnej w naszym projekcie konwersji Markdown do LaTeX.

- **[C#](https://docs.microsoft.com/en-us/dotnet/csharp/)**: Język programowania, w którym tworzymy logikę aplikacji. C# jest znany z wsparcia dla programowania obiektowego i jest często używany w aplikacjach wymagających wysokiej niezawodności i czytelności kodu.

- **[CommonMark Specification](https://spec.commonmark.org/0.31.2/)**: Podstawowa specyfikacja składni Markdown, na której opiera się nasz konwerter. CommonMark jest próbą unifikacji i standaryzacji Markdowna, co pozwala na zachowanie spójności w interpretacji tekstu na różnych platformach.

- **[Pandoc User’s Manual](https://pandoc.org/MANUAL.html#pandocs-markdown)**: Pandoc to wszechstronne narzędzie do konwersji plików Markdown na różne formaty, w tym LaTeX. W naszym projekcie korzystamy z części rozszerzeń Pandoc, co pozwala na obsługę niektórych specyficznych funkcji używanych w Markdown.

## Format wejściowy

Wejściem do programu jest plik Markdown o zredukowanej składni. Nasz konwerter bazuje głównie na specyfikacji CommonMark oraz, w mniejszym stopniu, na funkcjonalnościach oferowanych przez Pandoc.

Ograniczyliśmy składnię do następujących struktur, które nie mogą być w sobie zagnieżdżane:
- Nagłówki (tylko te rozpoczynające się od `#`)
- Linie poziome
- Paragrafy tekstu
- Listy numerowane i nienumerowane (z najwyżej trzypoziomowym zagnieżdżaniem, elementy nie są kontynuowane w następnej linii)
- Wcięte bloki kodu
- Odgrodzone bloki kodu (oznaczone przez dokładnie 3 `` ` `` lub `~` i zawsze poprawnie zamknięte)
- Cytaty blokowe (nie są kontynuowane w następnej linii, jeśli nie rozpoczyna się znakiem `>`)
- Obrazy
- Tabele

W samym tekście stylizowane są na razie tylko linki do stron internetowych.

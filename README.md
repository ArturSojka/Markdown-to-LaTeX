# Dane Studentów
- Artur Sojka, asojka@student.agh.edu.pl
- Piotr Waluszek, waluszekp@student.agh.edu.pl

# Opis i założenia projektu

Naszym projektem jest program konwertujący pliki z formatu Markdown na kod LaTeX.
Program został zaimplementowany w języku C#, z użyciem generatora parserów ANTLRv4.

# Spis tokenów

Definicja tokenów znajduje się w pliku [MarkdownLexer.g4](https://github.com/ArturSojka/Markdown-to-LaTeX/blob/main/Markdown-to-LaTeX/MarkdownLexer.g4)

# Gramatyka formatu

Używana przez nas gramatyka znajduje się w pliku [Markdown.g4](https://github.com/ArturSojka/Markdown-to-LaTeX/blob/main/Markdown-to-LaTeX/Markdown.g4)

# Instrukcja Obsługi Programu

Program MdToLatex konwertuje pliki w formacie Markdown na pliki w formacie LaTeX. Program można uruchomić z wiersza poleceń, podając odpowiednie argumenty.

### Użycie

```sh
Markdown-To-Latex in.md [out.tex]
```

### Argumenty

- `in.md`: Ścieżka do pliku Markdown, który ma być przekonwertowany.
- `[out.tex]` (opcjonalnie): Ścieżka do pliku wyjściowego w formacie LaTeX. Jeśli nie zostanie podany, plik wyjściowy zostanie nazwany tak samo jak plik wejściowy, ale z rozszerzeniem `.tex`.

## Przykład

Przykładowy plik Markdown i kod wygenerowany na jego podstawie znajdują się w pliku [Przykład działania.md](https://github.com/ArturSojka/Markdown-to-LaTeX/blob/main/Przykład%20działania.md).

# Dodatkowe informacje

Obsługiwane przez nasz program struktury Markdown to:
- Nagłówki
- Linie poziome
- Ogrodzone bloki kodu
- Wcięte bloki kodu
- Listy numerowane i nienumerowane
- Cytaty blokowe
- Tabele
- Linki do stron internetowych
- Zamieszczanie obrazów

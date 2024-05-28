# Przykład działania konwertera

### Wejście w formacie Markdown

~~~markdown
# Plik przykładowy

## Hello World!

### W Javie

```java
public class Main{
    public static void main(String[] args){
        System.out.println("Hello World!");
    }
};
```

### W Pythonie

    print("Hello World!")

## Eksperyment

### Pomiary

| Odległość (x) [cm]               | 0    | 0.5  | 1.0  | 1.5  | 2.0  | 2.5  |
|----------------------------------|:----:|:----:|:----:|:----:|:----:|:----:|
| Napięcie (U) [mV]                | e^11.6 | e^11.8 | e^11.9 | e^11.9 | e^11.9 | e^11.8 |
| Indukcja rzeczywista (B) [mT]    | 11.64| 11.49| 11.08| 10.45| 9.66 | 8.78 |
| Indukcja teoretyczna (B\|x) [mT] | 9.25 | 9.63 | 9.82 | 9.82 | 9.82 | 9.63 |
| Stężenie [%]                     | 5.5%  | 6.0%  | 6.5%  | 7.0%  | 7.5%  | 8.0%  |

### Schemat

![Schemat eksperymentu](schemat.jpg)

## Inne przykłady

Cytat blokowy:

>>> może zaczynać się od dowolnego poziomu
>>>
>
> oraz przechodzić między poziomami w dowolny sposób
>>
>> tak jak ten

Linki:

<https://www.wikipedia.com>

[Wyszukiwarka](https://www.google.com)

## \textit{To nie jest kursywa}

Linijka pozioma:

---

Nagłówek typu setex
===================

I jeszcze inny
--------------
~~~

### Wyjściowy kod LaTeX

~~~LaTeX
\documentclass{article}
\usepackage[polish]{babel}
\usepackage[utf8]{inputenc}
\usepackage[T1]{fontenc}
\usepackage{graphicx}
\usepackage{float}
\usepackage{listings}
\usepackage{hyperref}

\begin{document}
\section*{Plik przykładowy}

\subsection*{Hello World!}

\subsubsection*{W Javie}

\begin{lstlisting}[language=java]
public class Main{
    public static void main(String[] args){
        System.out.println("Hello World!");
    }
};
\end{lstlisting}

\subsubsection*{W Pythonie}

\begin{verbatim}
print("Hello World!")
\end{verbatim}

\subsection*{Eksperyment}

\subsubsection*{Pomiary}

\begin{table}[H]
\begin{tabular}{|l|c|c|c|c|c|c|}
\hline
\textbf{Odległość (x) [cm]} & \textbf{0} & \textbf{0.5} & \textbf{1.0} & \textbf{1.5} & \textbf{2.0} & \textbf{2.5} \\
\hline
Napięcie (U) [mV] & e\^{}11.6 & e\^{}11.8 & e\^{}11.9 & e\^{}11.9 & e\^{}11.9 & e\^{}11.8 \\
\hline
Indukcja rzeczywista (B) [mT] & 11.64 & 11.49 & 11.08 & 10.45 & 9.66 & 8.78 \\
\hline
Indukcja teoretyczna (B|x) [mT] & 9.25 & 9.63 & 9.82 & 9.82 & 9.82 & 9.63 \\
\hline
Stężenie [\%] & 5.5\% & 6.0\% & 6.5\% & 7.0\% & 7.5\% & 8.0\% \\
\hline
\end{tabular}
\end{table}

\subsubsection*{Schemat}

\begin{figure}[H]
\centering
\includegraphics[width=\linewidth]{schemat.jpg}
\caption{Schemat eksperymentu}
\end{figure}


\subsection*{Inne przykłady}

Cytat blokowy:

\begin{quote}
\begin{quote}
\begin{quote}
może zaczynać się od dowolnego poziomu

\end{quote}
\end{quote}

oraz przechodzić między poziomami w dowolny sposób
\begin{quote}

tak jak ten
\end{quote}
\end{quote}

Linki:

\url{https://www.wikipedia.com}

\href{https://www.google.com}{Wyszukiwarka}

\subsection*{\textbackslash textit\{To nie jest kursywa\}}

Linijka pozioma:

\begin{center}\rule{\linewidth}{1pt}\end{center}

\section*{Nagłówek typu setex}
\subsection*{I jeszcze inny}

\end{document}

~~~
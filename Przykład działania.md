# Przykład działania konwertera

### Wejście w formacie Markdown

~~~markdown
# Nagłówek 1
## Nagłówek 2
### Nagłówek 3

#### Nagłówek 4
##### Nagłówek 5
###### Nagłówek 6
#
######

---

```java
public class Main{
    public static void main(String[] args){
        System.out.println("Hello World!");
    }
};
```

| Odległość (x) [cm]               | 0    | 0.5  | 1.0  | 1.5  | 2.0  | 2.5  | 3.0  | 3.5  |
|----------------------------------|:----:|:----:|:----:|:----:|:----:|:----:|:----:|:----:|
| Napięcie (U) [mV]                | e^11.6 | e^11.8 | e^11.9 | e^11.9 | e^11.9 | e^11.8 | e^11.6 | e^11.3 |
| Indukcja rzeczywista (B) [mT]    | 11.64| 11.49| 11.08| 10.45| 9.66 | 8.78 | 7.87 | 6.99 |
| Indukcja teoretyczna (B\|x) [mT] | 9.25 | 9.63 | 9.82 | 9.82 | 9.82 | 9.63 | 9.25 | 8.68 |
| Stężenie [%]                     | 5.5%  | 6.0%  | 6.5%  | 7.0%  | 7.5%  | 8.0%  | 8.5%  | 9.0%  |

![Pillars of creation](pillars_of_creation.jpg)

## \textit{To nie jest kursywa}
~~~

### Wyjściowy kod LaTeX

~~~LaTeX
\documentclass{article}
\usepackage[polish]{babel}
\usepackage[utf8]{inputenc}
\usepackage[T1]{fontenc}
\usepackage{graphicx}
\usepackage{float}

\begin{document}
\section*{Nagłówek 1}
\subsection*{Nagłówek 2}
\subsubsection*{Nagłówek 3}
\paragraph*{Nagłówek 4}
\subparagraph*{Nagłówek 5}
Nagłówek 6
\section*{}

\begin{center}\rule{\linewidth}{1pt}\end{center}
\begin{verbatim}
public class Main{
    public static void main(String[] args){
        System.out.println("Hello World!");
    }
};
\end{verbatim}
\begin{table}[H]\begin{tabular}{|l|c|c|c|c|c|c|c|c|}
\hline
\textbf{Odległość (x) [cm]} & \textbf{0} & \textbf{0.5} & \textbf{1.0} & \textbf{1.5} & \textbf{2.0} & \textbf{2.5} & \textbf{3.0} & \textbf{3.5} \\
\hline
Napięcie (U) [mV] & e\^{}11.6 & e\^{}11.8 & e\^{}11.9 & e\^{}11.9 & e\^{}11.9 & e\^{}11.8 & e\^{}11.6 & e\^{}11.3 \\
\hline
Indukcja rzeczywista (B) [mT] & 11.64 & 11.49 & 11.08 & 10.45 & 9.66 & 8.78 & 7.87 & 6.99 \\
\hline
Indukcja teoretyczna (B|x) [mT] & 9.25 & 9.63 & 9.82 & 9.82 & 9.82 & 9.63 & 9.25 & 8.68 \\
\hline
Stężenie [\%] & 5.5\% & 6.0\% & 6.5\% & 7.0\% & 7.5\% & 8.0\% & 8.5\% & 9.0\% \\
\hline
\end{tabular}
\end{table}
\begin{figure}[H]
\centering
\includegraphics[width=\linewidth]{pillars_of_creation.jpg}
\caption{Pillars of creation}
\end{figure}

\subsection*{\textbackslash textit\{To nie jest kursywa\}}
\end{document}
~~~
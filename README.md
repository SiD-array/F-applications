# F# Applications in Data Science

<p align="center">
  <img src="https://fsharp.org/img/logo/fsharp.svg" alt="F# Logo" width="120"/>
</p>

<p align="center">
  <a href="https://f-applications.vercel.app/"><img src="https://img.shields.io/badge/🌐_Live_Demo-f--applications.vercel.app-06b6d4?style=for-the-badge" alt="Live Demo"/></a>
  <a href="https://github.com/SiD-array/F-applications"><img src="https://img.shields.io/badge/GitHub-Repository-181717?style=for-the-badge&logo=github" alt="GitHub"/></a>
</p>

A collection of projects demonstrating **functional programming approaches to data science** using F#. This repository showcases how F#'s expressive syntax, type safety, and functional paradigms make it an excellent choice for data analysis, transformation, and visualization workflows.

> **🔗 [View Live Demo →](https://f-applications.vercel.app/)** — Interactive website showcasing the project, visualizations, and code examples.

## Why F# for Data Science?

F# brings unique advantages to data science that complement traditional tools like Python and R:

| Feature | Benefit |
|---------|---------|
| **Type Inference** | Catch data type errors at compile time, not runtime |
| **Pipeline Operators** | Chain transformations naturally with `\|>` |
| **Immutability by Default** | Safer data transformations without side effects |
| **Pattern Matching** | Elegant handling of missing data and edge cases |
| **REPL Support** | Interactive exploration via F# Interactive (FSI) |
| **.NET Ecosystem** | Access to mature libraries and enterprise integration |

---

## Projects

### 🐧 Penguin Data Analysis

A complete data analysis pipeline exploring morphological measurements of penguins from the Palmer Archipelago. This project demonstrates the full data science workflow in F#.

**What it demonstrates:**
- Loading and exploring CSV datasets
- Data cleaning and preprocessing
- Handling missing values functionally
- Outlier detection and removal
- Feature engineering
- Interactive data visualization

[→ View Project Details](./PenguinDataDemo/README.md)

---

## Core Concepts Demonstrated

### 1. Data Loading with Deedle

[Deedle](https://fslab.org/Deedle/) is F#'s answer to pandas—a powerful data frame library for structured data manipulation.

```fsharp
open Deedle

// Load CSV into a typed data frame
let df = Frame.ReadCsv("penguins.csv", hasHeaders = true)
printfn "Rows: %d, Columns: %d" df.RowCount df.ColumnCount
```

### 2. Functional Data Transformation

F#'s pipeline operator (`|>`) enables readable, chainable data transformations:

```fsharp
let cleanedData = 
    rawData
    |> Frame.filterRows (fun _ row -> hasValidMeasurements row)
    |> Frame.mapCols (fun name col -> handleMissingValues name col)
    |> Frame.filterRows (fun _ row -> isWithinValidRange row)
```

### 3. Safe Missing Value Handling

Pattern matching and `OptionalValue<T>` provide compile-time safe handling of missing data:

```fsharp
let billLength = row.TryGetAs<float>("bill_length_mm")
let billDepth = row.TryGetAs<float>("bill_depth_mm")

// Count valid measurements using functional composition
let validCount = 
    [billLength.HasValue; billDepth.HasValue; flipperLength.HasValue; bodyMass.HasValue]
    |> List.filter id
    |> List.length
```

### 4. Interactive Visualization with Plotly.NET

[Plotly.NET](https://plotly.net/) brings interactive, publication-quality visualizations to F#:

```fsharp
open Plotly.NET

Chart.Scatter(x = flipperData, y = massData, mode = StyleParam.Mode.Markers)
|> Chart.withTitle "Flipper Length vs Body Mass"
|> Chart.withXAxisStyle "Flipper Length (mm)"
|> Chart.withYAxisStyle "Body Mass (g)"
|> Chart.saveHtml("plots/flipper_vs_mass.html")
```

### 5. Feature Engineering

Create derived features using Deedle's expressive column operations:

```fsharp
// Create bill area as a derived feature
let billAreaSeries = df?bill_length_mm * df?bill_depth_mm
df.AddColumn("bill_area_mm2", billAreaSeries)
```

---

## Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download) or later
- F# compiler (included with .NET SDK)

### Quick Start

```bash
# Clone the repository
git clone https://github.com/SiD-array/F-applications.git
cd F-applications

# Run the Penguin Data Analysis project
cd PenguinDataDemo
dotnet restore
dotnet run
```

---

## Project Structure

```
F-applications/
├── PenguinDataDemo/              # Penguin data analysis project
│   ├── src/
│   │   ├── DataLoad.fs           # Data loading utilities
│   │   ├── DataClean.fs          # Data cleaning & preprocessing
│   │   └── Visualization.fs      # Plotting & visualization
│   ├── plots/                    # Generated HTML visualizations
│   ├── Program.fs                # Main entry point
│   ├── penguins.csv              # Palmer Penguins dataset
│   └── PenguinDataDemo.fsproj    # Project configuration
├── docs/                         # Project showcase website
│   ├── index.html                # Main webpage
│   ├── style.css                 # Styling
│   ├── script.js                 # Interactions
│   └── plots/                    # Embedded visualizations
├── README.md                     # This file
└── .gitignore
```

---

## Technology Stack

| Library | Version | Purpose |
|---------|---------|---------|
| **F#** | .NET 9.0 | Functional-first programming language |
| **Deedle** | 3.0.0 | Data frames & series manipulation |
| **FSharp.Data** | 6.6.0 | Type providers for data access |
| **Plotly.NET** | 5.1.0 | Interactive visualizations |
| **Plotly.NET.Interactive** | 5.0.0 | Notebook integration |

---

## Learning Resources

### F# for Data Science
- [FsLab](https://fslab.org/) - F# data science packages
- [F# for Fun and Profit](https://fsharpforfunandprofit.com/) - Comprehensive F# tutorials
- [Deedle Documentation](https://fslab.org/Deedle/) - Data frame operations

### Visualization
- [Plotly.NET Documentation](https://plotly.net/) - Chart types and customization
- [XPlot](https://fslab.org/XPlot/) - Alternative plotting library

---

## Roadmap

Future projects planned for this repository:

- [ ] **Time Series Analysis** - Stock price prediction with ML.NET
- [ ] **Statistical Analysis** - Hypothesis testing and regression
- [ ] **Machine Learning** - Classification with ML.NET and F#
- [ ] **Data Pipeline** - ETL workflows with type providers

---

## Contributing

Contributions are welcome! Whether it's:
- 🐛 Bug fixes
- 📝 Documentation improvements
- ✨ New data science examples
- 🎨 Visualization enhancements

Please feel free to submit a Pull Request.

---

## License

This project is open source and available for educational purposes.

---

## Author

**SiD-array** - [GitHub Profile](https://github.com/SiD-array)

---

<p align="center">
  <i>Functional programming meets data science 📊</i>
</p>

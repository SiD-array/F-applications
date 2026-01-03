# 🐧 Penguin Data Analysis

A functional data analysis pipeline in F# exploring the Palmer Penguins dataset—demonstrating data loading, cleaning, transformation, and visualization using functional programming paradigms.

## Overview

This project analyzes morphological measurements of 344 penguins from three species (Adelie, Chinstrap, Gentoo) across three islands in the Palmer Archipelago, Antarctica. It showcases how F#'s functional features create clean, maintainable data science code.

## Data Pipeline

```
┌─────────────┐    ┌─────────────┐    ┌─────────────┐    ┌─────────────┐
│  Load CSV   │───►│   Clean &   │───►│  Feature    │───►│  Visualize  │
│   (Deedle)  │    │  Validate   │    │ Engineering │    │ (Plotly.NET)│
└─────────────┘    └─────────────┘    └─────────────┘    └─────────────┘
     344 rows          ~342 rows        + bill_area      4 interactive
                                                            charts
```

## Features

### Data Loading (`DataLoad.fs`)
- Reads CSV files using Deedle's `Frame.ReadCsv`
- Automatic type inference for columns
- Header detection and row/column counting

### Data Cleaning (`DataClean.fs`)

| Step | Operation | F# Concept |
|------|-----------|------------|
| 1 | Remove rows with >1 missing measurements | `Frame.filterRows` with `TryGetAs<T>` |
| 2 | Replace missing sex values with "Unknown" | `Frame.mapCols` with pattern matching |
| 3 | Remove outliers outside valid ranges | Range validation predicates |
| 4 | Create derived feature (bill area) | Column arithmetic operations |

**Validation Ranges:**
- Bill length: 30–60 mm
- Bill depth: 10–25 mm  
- Flipper length: 170–240 mm
- Body mass: 2,500–6,500 g

### Visualization (`Visualization.fs`)

Four interactive charts generated with Plotly.NET:

1. **Scatter Plot**: Flipper Length vs Body Mass
2. **Box Plot**: Bill Length Distribution
3. **Histogram**: Body Mass Distribution  
4. **Scatter Plot**: Bill Area vs Body Mass (derived feature)

## Dataset

The [Palmer Penguins](https://allisonhorst.github.io/palmerpenguins/) dataset includes:

| Column | Description | Type |
|--------|-------------|------|
| `species` | Penguin species | Adelie, Chinstrap, Gentoo |
| `island` | Island name | Torgersen, Biscoe, Dream |
| `bill_length_mm` | Bill length | Float (mm) |
| `bill_depth_mm` | Bill depth | Float (mm) |
| `flipper_length_mm` | Flipper length | Float (mm) |
| `body_mass_g` | Body mass | Float (g) |
| `sex` | Penguin sex | male, female |
| `year` | Year of observation | 2007, 2008, 2009 |

## Usage

```bash
# From the PenguinDataDemo directory
dotnet restore
dotnet build
dotnet run
```

**Output:**
```
 Loading dataset...
Rows: 344, Columns: 9

 Cleaning dataset...
→ Initial dataset: 344 rows
→ After removing rows with too many missing values: 342 rows
→ After data validation: 342 rows
→ Final cleaned dataset: 342 rows

 Creating scatter plot of Flipper Length vs Body Mass...
→ Showing boxplot...
→ Showing histogram...
→ Showing bill area vs body mass scatter plot...
```

Four browser windows will open with interactive Plotly charts.

## Code Highlights

### Pipeline-Based Data Flow
```fsharp
let raw = loadPenguins "penguins.csv"
let cleaned = cleanData raw

scatterFlipperVsMass cleaned
billLengthBoxplot cleaned
histBodyMass cleaned
scatterBillAreaVsMass cleaned
```

### Functional Missing Value Handling
```fsharp
// Safe extraction with OptionalValue
let billLength = row.TryGetAs<float>("bill_length_mm")
let validCount = 
    [billLength.HasValue; billDepth.HasValue; ...]
    |> List.filter id
    |> List.length
```

### Declarative Validation
```fsharp
let isValidBillLength = 
    not billLength.HasValue || 
    (billLength.Value >= 30.0 && billLength.Value <= 60.0)
```

## Project Structure

```
PenguinDataDemo/
├── src/
│   ├── DataLoad.fs         # Data loading module
│   ├── DataClean.fs        # Cleaning & preprocessing
│   └── Visualization.fs    # Chart generation
├── Program.fs              # Entry point & orchestration
├── penguins.csv            # Dataset (344 rows)
└── PenguinDataDemo.fsproj  # Project configuration
```

## Dependencies

```xml
<PackageReference Include="Deedle" Version="3.0.0" />
<PackageReference Include="FSharp.Data" Version="6.6.0" />
<PackageReference Include="Plotly.NET" Version="5.1.0" />
<PackageReference Include="Plotly.NET.Interactive" Version="5.0.0" />
```

## Extending This Project

Ideas for further exploration:

- **Species Comparison**: Group visualizations by species
- **Statistical Tests**: T-tests comparing species measurements
- **Machine Learning**: Classify species based on measurements
- **Correlation Analysis**: Heatmap of feature correlations
- **Time Trends**: Analyze changes across years


# Penguin Data Analysis with F#

A data analysis and visualization project in F# that explores penguin morphological measurements. This project demonstrates data loading, cleaning, and visualization using F# functional programming paradigms.

## Overview

This project analyzes penguin data from the Palmer Archipelago, performing data cleaning operations and generating various visualizations to explore relationships between different morphological features such as bill length, flipper length, and body mass.

## Features

- **Data Loading**: Loads penguin data from CSV files using Deedle data frames
- **Data Cleaning**: 
  - Removes rows with excessive missing values
  - Handles missing categorical data
  - Validates data ranges to remove outliers
  - Creates derived features (e.g., bill area)
- **Visualization**: Generates interactive plots using Plotly.NET:
  - Scatter plot: Flipper Length vs Body Mass
  - Box plot: Bill Length Distribution
  - Histogram: Body Mass Distribution
  - Scatter plot: Bill Area vs Body Mass

## Project Structure

```
PenguinDataDemo/
├── src/
│   ├── DataLoad.fs      # Data loading module
│   ├── DataClean.fs     # Data cleaning and preprocessing
│   └── Visualization.fs # Plotting and visualization functions
├── Program.fs            # Main entry point
├── penguins.csv         # Dataset file
└── PenguinDataDemo.fsproj # Project file
```

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download) or later
- F# compiler (included with .NET SDK)

## Dependencies

The project uses the following NuGet packages:

- **Deedle** (3.0.0) - Data frame library for F#
- **FSharp.Data** (6.6.0) - F# type providers for data access
- **Plotly.NET** (5.1.0) - Interactive plotting library
- **Plotly.NET.Interactive** (5.0.0) - Interactive visualization support

## Installation

1. Clone the repository:
```bash
git clone https://github.com/SiD-array/F-applications.git
cd F-applications/PenguinDataDemo
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Build the project:
```bash
dotnet build
```

## Usage

Run the application:
```bash
dotnet run
```

The program will:
1. Load the penguin dataset from `penguins.csv`
2. Clean and preprocess the data
3. Generate and display four visualizations:
   - Scatter plot of flipper length vs body mass
   - Box plot of bill length distribution
   - Histogram of body mass distribution
   - Scatter plot of bill area vs body mass

## Data Cleaning Process

The data cleaning module performs the following operations:

1. **Missing Value Handling**: Removes rows with fewer than 3 out of 4 key measurements (bill length, bill depth, flipper length, body mass)
2. **Categorical Data Cleaning**: Replaces empty or null sex values with "Unknown"
3. **Outlier Detection**: Filters out measurements outside reasonable ranges:
   - Bill length: 30-60 mm
   - Bill depth: 10-25 mm
   - Flipper length: 170-240 mm
   - Body mass: 2500-6500 g
4. **Feature Engineering**: Creates derived features like bill area (bill length × bill depth)

## Dataset

The project uses a penguin dataset containing measurements of penguins from the Palmer Archipelago. The dataset includes:

- **Species**: Adelie, Chinstrap, Gentoo
- **Island**: Torgersen, Biscoe, Dream
- **Measurements**: Bill length, bill depth, flipper length, body mass
- **Metadata**: Sex, year of observation

## Technologies

- **F#** - Functional-first programming language
- **Deedle** - Data frame library for exploratory data analysis
- **Plotly.NET** - Interactive data visualization
- **.NET 9.0** - Runtime and framework

## License

This project is open source and available for educational purposes.

## Author

SiD-array

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.


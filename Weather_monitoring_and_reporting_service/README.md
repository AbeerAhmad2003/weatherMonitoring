# Weather Monitoring Application

A C# console application that simulates a real-time weather monitoring and reporting service. The application supports multiple weather data formats (JSON, XML, etc.) and allows dynamic creation of weather bots using **Simple Factory** and parsers using **Factory Method** design patterns.

---

## Features

- Parse weather data from **JSON** and **XML** formats.
- Dynamically create and manage **Weather Bots**:
  - **RainBot**: Activates when humidity exceeds a threshold.
  - **SunBot**: Activates when temperature rises above a threshold.
  - **SnowBot**: Activates when temperature drops below a threshold.
- Configurable bot settings through a JSON configuration file.
- Extensible design to easily add new data formats without changing existing code.

---

## Design Patterns Used

- **Observer Pattern**: `WeatherStation` notifies all registered bots of new weather data.
- **Simple Factory Pattern**: `BotFactory` creates bots based on configuration.
- **Factory Method Pattern**: Parsers implement `IWeatherDataParser` interface, and each parser type has a creator class to instantiate it.
- **Strategy Pattern**: Parser classes encapsulate parsing logic for different data formats.

---

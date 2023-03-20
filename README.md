<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/rhys-wootton/Darwin.Net?style=flat-square
[contributors-url]: https://github.com/othneildrew/Best-README-Template/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/othneildrew/Best-README-Template.svg?style=for-the-badge
[forks-url]: https://github.com/othneildrew/Best-README-Template/network/members
[stars-shield]: https://img.shields.io/github/stars/othneildrew/Best-README-Template.svg?style=for-the-badge
[stars-url]: https://github.com/othneildrew/Best-README-Template/stargazers
[issues-shield]: https://img.shields.io/github/issues/othneildrew/Best-README-Template.svg?style=for-the-badge
[issues-url]: https://github.com/othneildrew/Best-README-Template/issues
[license-shield]: https://img.shields.io/github/license/rhys-wootton/Darwin.Net?style=flat-square
[license-url]: https://github.com/rhys-wootton/Darwin.Net/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-Connect%20with%20me!-0077b5?style=flat-square&logo=LinkedIn
[linkedin-url]: https://www.linkedin.com/in/rhyswootton2212/
[product-screenshot]: images/screenshot.png

<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a name="readme-top"></a>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->

<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/othneildrew/Best-README-Template">
    <img src=".gitassets/Long Logo.svg" alt="Logo" width="500">
  </a>

  <h3 align="center">Darwin.Net</h3>

  <p align="center">
    A powerful and user-friendly C# wrapper for the National Rail Darwin OpenLDBWS API, powered by .NET 7
    <br />
    <a href="https://github.com/othneildrew/Best-README-Template"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/othneildrew/Best-README-Template">View Demo</a>
    ·
    <a href="https://github.com/othneildrew/Best-README-Template/issues">Report Bug</a>
    ·
    <a href="https://github.com/othneildrew/Best-README-Template/issues">Request Feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

**Darwin.Net** is a versatile and efficient C# wrapper for the UK's National Rail Darwin OpenLDBWS API, specifically designed to simplify railway data integration tasks. 

Its features include:

- **Asynchronous Requests**: Leverage the power of async/await to make non-blocking requests.
- **HttpClient**: By using HttpClient instead of SOAP/WCF, Darwin.Net benefits from improved performance, better resource management, and modern networking capabilities. HttpClient is lighter, faster, and more flexible than its alternatives, making it the ideal choice for a contemporary C# wrapper.
- **Multi-platform Support**: Harness the cross-platform capabilities of .NET 7 to deploy applications using Darwin.Net on a wide range of operating systems, including Windows, macOS, and Linux.
- **Zero Dependencies**: Darwin.Net library is self-contained and does not rely on any external packages, making it easy to integrate and maintain in your projects."

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- GETTING STARTED -->
## Getting Started

To get a local copy built, follow these simple example steps.

### Installation

1. Obtain an API key from [National Rail Enquiries](http://realtime.nationalrail.co.uk/OpenLDBWSRegistration/)
2. Clone the repository
   ```sh
   git clone https://github.com/rhys-wootton/Darwin.Net.git
   ```
3. Create an `app.config   ` file within the Darwin.Net project and add the following
   ```xml
   <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
        <appSettings>
            <add key="DarwinApiKey" value="YOUR_API_KEY" />
            <add key="DarwinUrl" value="https://lite.realtime.nationalrail.co.uk/OpenLDBWS/ldb12.asmx"/>
            <add key="DarwinActionNameUrl" value="http://thalesgroup.com/RTTI/2021-11-01/ldb/"/>
            <add key="DarwinTokenTypeUrl" value="http://thalesgroup.com/RTTI/2013-11-28/Token/types"/>
        </appSettings>
    </configuration>
   ```
4. Build  the project
<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

TODO



<!-- ROADMAP -->
## Roadmap

TODO

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the GNU AGPLv3 License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* [Best README Template](https://github.com/othneildrew/Best-README-Template)

<p align="right">(<a href="#readme-top">back to top</a>)</p>
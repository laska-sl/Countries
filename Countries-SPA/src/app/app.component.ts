import { Component, OnInit } from '@angular/core';

import { Country } from './models/country';
import { CountriesService } from './services/countries.service';

enum Modes {
  searching,
  adding,
  asking,
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: []
})
export class AppComponent implements OnInit {
  searchedCountryName = '';
  country: Country;
  Modes = Modes;
  mode: Modes = Modes.searching;

  constructor(private countriesService: CountriesService) { }

  ngOnInit(): void {
    this.countriesService.countryCreated.subscribe(
      () => this.mode = Modes.searching
    );
  }

  searchCountry() {
    this.countriesService.getCountryByName(this.searchedCountryName).subscribe(
      (data: Country) => {
        this.country = data;
        if (!this.country) {
          this.mode = Modes.asking;
        }
      },
      () => this.mode = Modes.asking
    );
  }

}

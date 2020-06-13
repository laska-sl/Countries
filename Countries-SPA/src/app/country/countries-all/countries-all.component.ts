import { Component, OnInit } from '@angular/core';

import { Country } from 'src/app/models/country';
import { CountriesService } from 'src/app/services/countries.service';

@Component({
  selector: 'app-countries-all',
  templateUrl: './countries-all.component.html',
  styleUrls: []
})
export class CountriesAllComponent implements OnInit {
  countries: Country[];

  constructor(private countriesService: CountriesService) { }

  ngOnInit(): void {
    this.countriesService.getCountries().subscribe(
      data => this.countries = data
    );

    this.countriesService.countryCreated.subscribe(
      () => this.countriesService.getCountries().subscribe(
        data => this.countries = data
      )
    );
  }

}

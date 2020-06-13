import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { CountriesService } from 'src/app/services/countries.service';
import { Country } from 'src/app/models/country';

@Component({
  selector: 'app-country-add',
  templateUrl: './country-add.component.html',
  styleUrls: []
})
export class CountryAddComponent implements OnInit {
  @Input() countryName: string;
  country: Country = {
    name: this.countryName,
    code: '',
    area: 0,
    population: 0,
    capitalName: '',
    regionName: ''
  };

  constructor(private countriesService: CountriesService) { }

  ngOnInit(): void {
    this.country.name = this.countryName;
  }

  createCountry() {
    this.countriesService.createCountry(this.country).subscribe(
      data => this.country = data,
    );

    this.countriesService.countryCreated.next(this.country);
  }
}

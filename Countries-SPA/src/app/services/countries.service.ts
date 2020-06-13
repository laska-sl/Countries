import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { map } from 'rxjs/operators';

import { Country } from '../models/country';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CountriesService {
  baseUrl = environment.apiUrl + 'countries/';
  countryCreated = new Subject<Country>();

  constructor(private http: HttpClient) { }

  getCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(this.baseUrl);
  }

  getCountryByName(name: string) {
    return this.http
      .get('https://restcountries.eu/rest/v2/name/' + name)
      .pipe(
        map((result: any) => {
          return {
            name: result[0].name,
            code: result[0].alpha2Code,
            capitalName: result[0].capital,
            area: result[0].area,
            population: result[0].population,
            regionName: result[0].region
          } as Country;
        })
      );
  }

  createCountry(country: Country): Observable<Country> {
    return this.http.post<Country>(this.baseUrl, country);
  }
}

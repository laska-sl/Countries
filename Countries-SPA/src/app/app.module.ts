import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { CountriesService } from './services/countries.service';
import { CountryAddComponent } from './country/country-add/country-add.component';
import { CountryComponent } from './country/country/country.component';
import { CountriesAllComponent } from './country/countries-all/countries-all.component';

@NgModule({
  declarations: [
    AppComponent,
    CountryAddComponent,
    CountryComponent,
    CountriesAllComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [
    CountriesService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

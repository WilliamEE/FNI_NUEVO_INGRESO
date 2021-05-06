import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FormularioNIComponent } from './components/formulario-ni/formulario-ni.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { HttpClientModule  } from '@angular/common/http'

@NgModule({
  declarations: [
    AppComponent,
    FormularioNIComponent,
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), // ToastrModule added
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './modules/home/home.component';
import { CoreModule } from './core/core.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FooterComponent } from './core/footer/footer.component';
import { UserModule } from './modules/user/user.module';
import { CustomMaterialModule } from './modules/custom-material.module';
import { LyricModule } from './modules/lyric/lyric.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { TokenInterceptor } from './core/interceptors/auth/token-interceptor';
import { UserService } from './core/services/user.service';
import { InputValidationDirective } from './shared/directives/input-validation.directive';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FooterComponent,
    InputValidationDirective
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CustomMaterialModule,
    AppRoutingModule,
    CoreModule,
    UserModule,
    LyricModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    UserService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

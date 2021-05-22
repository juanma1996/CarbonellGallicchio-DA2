import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginRoutes } from './login-routing.module';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './login.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(LoginRoutes),
  ],
  declarations: [
    LoginComponent
  ],
  exports:[
    LoginComponent
  ]
})
export class LoginModule { }

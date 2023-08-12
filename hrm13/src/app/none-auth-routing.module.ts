import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/auth/login/login.component';
import { LoginLayoutComponent } from './login-layout/login-layout.component';

const routes: Routes = [
  {
    path: '', component: LoginLayoutComponent, children: [
      { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
      { path: '', redirectTo: '/login', pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
    ]
  },


];


@NgModule({
  declarations: [],
  exports: [RouterModule],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)

  ]
})
export class NoneAuthRoutingModule { }

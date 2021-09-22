import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DatabaseSettingsComponent } from './layouts/database-settings/database-settings.component';
import { LoginComponent } from './layouts/login/login.component';

/**
 * 
 */
const routes: Routes = [
  { path: '', component: DatabaseSettingsComponent },
  { path: 'login', component: LoginComponent }
];

/**
 * 
 */
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

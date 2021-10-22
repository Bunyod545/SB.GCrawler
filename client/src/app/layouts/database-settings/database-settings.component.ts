import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DatabaseConfigInfo } from '../../common/services/database-settings/models/database-config-info';
import { DatabaseSettingsService } from '../../common/services/database-settings/database-settings-service';

/**
 * 
 */
@Component({
  selector: 'database-settings',
  templateUrl: './database-settings.component.html',
  styleUrls: ['./database-settings.component.css']
})
export class DatabaseSettingsComponent implements OnInit {

  /**
   * 
   */
  config: DatabaseConfigInfo = new DatabaseConfigInfo();

  /**
   * 
   */
  isError?: boolean;

  /**
   * 
   */
  isLoading?: boolean;

  /**
   * 
   */
  constructor(private settingsService: DatabaseSettingsService, private router: Router) { }

  /**
   * 
   */
  ngOnInit(): void {

  }

  /**
   * 
   */
  onNextClick() {
    this.isLoading = true;
    setTimeout(() => this.validate(), 1000);
  }

  /**
   * 
   */
  validate() {
    this.settingsService.validateAndSave(this.config).subscribe(
      res => this.validateAndSaveSuccess(res),
      err => this.validateAndSaveError(err)
    )
  }

  /**
   * 
   * @param res 
   */
  validateAndSaveSuccess(res: boolean): void {
    this.isLoading = false;
    this.isError = !res;

    if (res)
      this.router.navigateByUrl('initUser')
  }

  /**
   * 
   * @param err 
   */
  validateAndSaveError(err: any): void {
    this.isLoading = false;
    this.isError = true;
  }

  /**
   * 
   */
  hideError() {
    this.isError = false;
  }
}

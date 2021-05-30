import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-content-importer-dashboard',
  templateUrl: './content-importer-dashboard.component.html',
  styleUrls: ['./content-importer-dashboard.component.scss']
})
export class ContentImporterDashboardComponent implements OnInit {
  importerForm: FormGroup;
  imported: boolean = false;

  importerTypesData = []

  constructor(
    private fb: FormBuilder,
    public toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.initializeContentImporterForm();
  }

  initializeContentImporterForm(): void {
    this.importerForm = this.fb.group({
      importerType: new FormControl(null),
      filePath: new FormControl(null),
    })
  }

  importContent() {

  }

  importerTypeSelect(item: any){

  }

  importerTypeDeSelect(item: any){

  }

}

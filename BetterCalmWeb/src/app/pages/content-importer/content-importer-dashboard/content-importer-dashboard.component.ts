import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ContentImporterService } from 'src/app/services/content-importer/content-importer.service';
import { catchError } from 'rxjs/operators';
import { ToastService } from 'src/app/common/toast.service';

@Component({
  selector: 'app-content-importer-dashboard',
  templateUrl: './content-importer-dashboard.component.html',
  styleUrls: ['./content-importer-dashboard.component.scss']
})
export class ContentImporterDashboardComponent implements OnInit {
  importerForm: FormGroup;
  imported: boolean = false;
  selectedType;
  importerTypesData = [];

  constructor(
    private fb: FormBuilder,
    public customToastr: ToastService,
    public contentImporterService: ContentImporterService,
  ) { }

  ngOnInit(): void {
    this.initializeContentImporterForm();
    this.contentImporterService.get()
      .subscribe(
        response => {
          this.mapData(response, this.importerTypesData);
        },
        catchError => {
          this.customToastr.setError(catchError.error)
        }
      )
  }

  initializeContentImporterForm(): void {
    this.importerForm = this.fb.group({
      importerType: new FormControl(null, Validators.required),
      filePath: new FormControl(null, Validators.required),
    })
  }

  importContent() {
    this.imported = true;
    if (!this.importerForm.invalid) {
      this.contentImporterService.add(this.importerForm.value)
        .subscribe(
          response => {
            this.customToastr.setSuccess("The content was imported successfully");
            this.resetForm();
          },
          catchError => {
            this.customToastr.setError(catchError);
          }
        )
    }
    else {
      this.customToastr.setError("Please verify the entered data.");
    }
  }

  get importerType(): FormControl {
    return this.importerForm.get('importerType') as FormControl;
  }

  importerTypeSelect(item: any) {
    this.importerType.setValue(item.itemName);
  }

  importerTypeDeSelect(item: any) {
    this.importerType.reset();
  }

  mapData(originalData, multiSelectData) {
    for (let index = 0; index < originalData.length; index++) {
      var data = {
        id: index,
        itemName: originalData[index],
      }
      multiSelectData.push(data);
    }
  }

  resetForm() {
    this.imported = false;
    this.importerForm.reset();
    this.selectedType = [];
  }
}

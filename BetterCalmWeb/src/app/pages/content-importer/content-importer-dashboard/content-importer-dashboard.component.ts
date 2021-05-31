import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ContentImporterService } from 'src/app/services/content-importer/content-importer.service';
import { catchError } from 'rxjs/operators';

@Component({
  selector: 'app-content-importer-dashboard',
  templateUrl: './content-importer-dashboard.component.html',
  styleUrls: ['./content-importer-dashboard.component.scss']
})
export class ContentImporterDashboardComponent implements OnInit {
  importerForm: FormGroup;
  imported: boolean = false;

  importerTypesData = [];

  constructor(
    private fb: FormBuilder,
    public toastr: ToastrService,
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
          this.setError(catchError.error)
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
            console.log(response)
            this.setSuccess();
          },
          catchError => {
            this.setError(catchError);
          }
        )
    }
    else {
      this.setError("Please verify the entered data.");
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

  private setError(message) {
    this.toastr.show(
      '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
      message,
      {
        timeOut: 5000,
        closeButton: true,
        enableHtml: true,
        toastClass: "alert alert-danger alert-with-icon",
        positionClass: "toast-top-right"
      }
    );
  }

  private setSuccess() {
    this.toastr.show(
      '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
      "The content was imported successfully",
      {
        timeOut: 5000,
        closeButton: true,
        enableHtml: true,
        toastClass: "alert alert-success alert-with-icon",
        positionClass: "toast-top-right"
      }
    );
  }

}

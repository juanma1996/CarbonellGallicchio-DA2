import { Injectable } from '@angular/core';
import swal from "sweetalert2";
import { ToastService } from './toast.service';

@Injectable({
    providedIn: 'root'
})
export class AlertService {
    constructor(
    ) { }

    showAlert(mainText, successText, callbackConfirm) {
        swal
            .fire({
                title: mainText,
                text: "You won't be able to revert this!",
                icon: "warning",
                showCancelButton: true,
                customClass: {
                    cancelButton: "btn btn-danger",
                    confirmButton: "btn btn-success mr-1",
                },
                confirmButtonText: successText,
                buttonsStyling: false
            })
            .then(result => {
                if (result.value) {
                    callbackConfirm();
                }
            })
    }

}
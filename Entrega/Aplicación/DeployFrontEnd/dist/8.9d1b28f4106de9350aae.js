(window.webpackJsonp=window.webpackJsonp||[]).push([[8],{LNOL:function(t,e,o){"use strict";o.r(e);var i=o("ofXK"),n=o("tyNb"),r=o("6Y5f"),a=o("aeTR"),u=o("iBw7"),s=o("fXoL"),d=o("+8JC"),c=function(){function t(t,e,o,i){this.route=t,this.audioContentService=e,this.sessionService=o,this.customToastr=i,this.audioContents=[]}return t.prototype.ngOnInit=function(){this.categoryId=this.route.snapshot.paramMap.get("categoryId"),this.playlistId=Number(this.route.snapshot.paramMap.get("playlistId")),this.getAudioContents(this.playlistId)},t.prototype.getAudioContents=function(t){var e=this;this.audioContentService.getAudioContentByPlaylist(t).subscribe((function(t){e.audioContents=t}),(function(t){e.customToastr.setError(t)}))},t.prototype.updateAudios=function(){this.getAudioContents(this.playlistId)},t.prototype.delete=function(t){var e=this;this.audioContentService.delete(t).subscribe((function(t){e.customToastr.setSuccess("The audio content was successfully deleted"),e.getAudioContents(e.playlistId)}),(function(t){e.customToastr.setError(t)}))},t.\u0275fac=function(e){return new(e||t)(s.Jb(n.a),s.Jb(r.a),s.Jb(a.a),s.Jb(u.a))},t.\u0275cmp=s.Db({type:t,selectors:[["app-audio-content-dashboard"]],decls:9,vars:1,consts:[[1,"content"],[1,"row"],[1,"col-12"],[1,"card"],[1,"card-header"],[1,"title","p-2"],[3,"audios","updateAudios"]],template:function(t,e){1&t&&(s.Ob(0,"div",0),s.Ob(1,"div",1),s.Ob(2,"div",2),s.Ob(3,"div",3),s.Ob(4,"div",4),s.Ob(5,"div",1),s.Ob(6,"h2",5),s.Dc(7,"Audio Contents of Playlist"),s.Nb(),s.Nb(),s.Ob(8,"app-audio-content-table",6),s.Vb("updateAudios",(function(){return e.updateAudios()})),s.Nb(),s.Nb(),s.Nb(),s.Nb(),s.Nb(),s.Nb()),2&t&&(s.xb(8),s.fc("audios",e.audioContents))},directives:[d.a],styles:[""]}),t}(),l=o("3Pt+"),f=o("uNdA"),b=function(){function t(t,e,o){this.audioContentService=t,this.customToastr=e,this.fb=o,this.create=!1,this.newPlaylist=!1}return t.prototype.ngOnInit=function(){this.initializeAudioContentForm()},t.prototype.initializeAudioContentForm=function(){this.playableContentForm.submited=!1,this.createAudioContentForm=this.fb.group({name:new l.e(null,l.t.required),creatorName:new l.e(null,l.t.required),duration:new l.e(null,l.t.required),imageUrl:new l.e(null),audioUrl:new l.e(null,[l.t.pattern(/^(?:(?:(?:https?|ftp):)?\/\/)(?:\S+(?::\S*)?@)?(?:(?!(?:10|127)(?:\.\d{1,3}){3})(?!(?:169\.254|192\.168)(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})).?)(?::\d{2,5})?(?:[\/?#]\S*)?$/i),l.t.required]),categories:this.fb.array([],l.t.required),playlists:this.fb.array([])}),this.selectedPlaylist=this.fb.group({})},t.prototype.createAudioContent=function(){var t=this;this.playableContentForm.transformTime(),this.playableContentForm.submited=!0,this.createAudioContentForm.invalid?this.customToastr.setError("Please verify the entered data."):this.audioContentService.add(this.createAudioContentForm.value).subscribe((function(e){t.customToastr.setSuccess("The audio content was successfully created"),t.playableContentForm.resetForm()}),(function(e){t.customToastr.setError(e)}))},Object.defineProperty(t.prototype,"playlists",{get:function(){return this.createAudioContentForm.get("playlists")},enumerable:!1,configurable:!0}),t.\u0275fac=function(e){return new(e||t)(s.Jb(r.a),s.Jb(u.a),s.Jb(l.d))},t.\u0275cmp=s.Db({type:t,selectors:[["app-create-audio-content"]],viewQuery:function(t,e){var o;1&t&&s.yc(f.a,!0),2&t&&s.oc(o=s.Wb())&&(e.playableContentForm=o.first)},decls:12,vars:3,consts:[[3,"formGroup"],[1,"content"],[1,"row"],[1,"col-md-8"],[1,"card"],[1,"card-header"],[1,"title"],[3,"parentForm","isAudio"],[1,"card-footer"],["type","submit",1,"btn","btn-fill","btn-danger",3,"click"]],template:function(t,e){1&t&&(s.Ob(0,"form",0),s.Ob(1,"div",1),s.Ob(2,"div",2),s.Ob(3,"div",3),s.Ob(4,"div",4),s.Ob(5,"div",5),s.Ob(6,"h2",6),s.Dc(7,"Create audio content"),s.Nb(),s.Nb(),s.Kb(8,"app-playable-content-form",7),s.Ob(9,"div",8),s.Ob(10,"button",9),s.Vb("click",(function(){return e.createAudioContent()})),s.Dc(11,"Create audio content"),s.Nb(),s.Nb(),s.Nb(),s.Nb(),s.Nb(),s.Nb(),s.Nb()),2&t&&(s.fc("formGroup",e.createAudioContentForm),s.xb(8),s.fc("parentForm",e.createAudioContentForm)("isAudio",!0))},directives:[l.v,l.o,l.h,f.a],styles:[""]}),t}(),p=o("Tk1w"),m=o("mrSG"),h=[{path:"edit/:audioContentId",component:function(){function t(t,e,o,i,n){this.audioContentService=t,this.customToastr=e,this.fb=o,this.route=i,this.router=n,this.editingAudioContent={},this.newPlaylist=!1}return t.prototype.ngOnInit=function(){this.audioContentId=Number(this.route.snapshot.paramMap.get("audioContentId")),this.getAudioContentInfo(this.audioContentId),this.initializeAudioContentForm(this.editingAudioContent)},t.prototype.getAudioContentInfo=function(t){return Object(m.b)(this,void 0,void 0,(function(){var e=this;return Object(m.e)(this,(function(o){return this.audioContentService.getAudioContentById(t).subscribe((function(t){e.editingAudioContent=t,e.updateForm(),e.updateMultiSelects()}),(function(t){e.router.navigateByUrl("categories"),e.customToastr.setError(t)})),[2]}))}))},t.prototype.initializeAudioContentForm=function(t){this.editAudioContentForm=this.fb.group({id:new l.e(this.audioContentId,l.t.required),name:new l.e(t.name,l.t.required),creatorName:new l.e(t.creatorName,l.t.required),duration:new l.e(null,l.t.required),imageUrl:new l.e(t.imageUrl),audioUrl:new l.e(t.audioUrl,[l.t.pattern(/^(?:(?:(?:https?|ftp):)?\/\/)(?:\S+(?::\S*)?@)?(?:(?!(?:10|127)(?:\.\d{1,3}){3})(?!(?:169\.254|192\.168)(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})).?)(?::\d{2,5})?(?:[\/?#]\S*)?$/i),l.t.required]),categories:this.fb.array([],l.t.required),playlists:this.fb.array([])}),this.selectedPlaylist=this.fb.group({})},Object.defineProperty(t.prototype,"categories",{get:function(){return this.editAudioContentForm.get("categories")},enumerable:!1,configurable:!0}),t.prototype.updateForm=function(){this.editAudioContentForm.get("name").setValue(this.editingAudioContent.name),this.editAudioContentForm.get("creatorName").setValue(this.editingAudioContent.creatorName),this.editAudioContentForm.get("imageUrl").setValue(this.editingAudioContent.imageUrl),this.editAudioContentForm.get("audioUrl").setValue(this.editingAudioContent.audioUrl),this.editAudioContentForm.get("duration").setValue(this.toDate(this.editingAudioContent.duration))},t.prototype.updateMultiSelects=function(){var t=this;this.editingAudioContent.categories.forEach((function(e){var o=t.fb.group({id:e.id,name:e.name});t.playableContentForm.selectedCategory=o,t.categories.push(o),t.playableContentForm.originalCategories.push({id:e.id,itemName:e.name})})),this.editingAudioContent.playlists.forEach((function(e){var o=t.fb.group({id:e.id,name:e.name,description:e.description});t.playlists.push(o),t.playableContentForm.originalPlaylists.push({id:e.id,itemName:e.name})}))},t.prototype.toDate=function(t){var e=new Date;return e.setHours(t.substr(0,t.indexOf(":"))),e.setMinutes(t.substr(3,t.indexOf(":"))),e.setSeconds(t.substr(6,t.indexOf(":"))),e},t.prototype.updateAudioContent=function(){var t=this;this.playableContentForm.transformTime(),this.playableContentForm.submited=!0,this.editAudioContentForm.invalid?this.customToastr.setError("Please verify the entered data."):this.audioContentService.update(this.editAudioContentForm.value,this.audioContentId).subscribe((function(e){t.customToastr.setSuccess("The audio content was successfully updated"),t.playableContentForm.resetForm()}),(function(e){t.customToastr.setError(e)}))},Object.defineProperty(t.prototype,"playlists",{get:function(){return this.editAudioContentForm.get("playlists")},enumerable:!1,configurable:!0}),t.\u0275fac=function(e){return new(e||t)(s.Jb(r.a),s.Jb(u.a),s.Jb(l.d),s.Jb(n.a),s.Jb(n.b))},t.\u0275cmp=s.Db({type:t,selectors:[["app-edit-audio-content"]],viewQuery:function(t,e){var o;1&t&&s.yc(f.a,!0),2&t&&s.oc(o=s.Wb())&&(e.playableContentForm=o.first)},decls:12,vars:3,consts:[[3,"formGroup"],[1,"content"],[1,"row"],[1,"col-md-8"],[1,"card"],[1,"card-header"],[1,"title"],[3,"parentForm","isAudio"],[1,"card-footer"],["type","submit",1,"btn","btn-fill","btn-danger",3,"click"]],template:function(t,e){1&t&&(s.Ob(0,"form",0),s.Ob(1,"div",1),s.Ob(2,"div",2),s.Ob(3,"div",3),s.Ob(4,"div",4),s.Ob(5,"div",5),s.Ob(6,"h2",6),s.Dc(7,"Edit audio content"),s.Nb(),s.Nb(),s.Kb(8,"app-playable-content-form",7),s.Ob(9,"div",8),s.Ob(10,"button",9),s.Vb("click",(function(){return e.updateAudioContent()})),s.Dc(11,"Edit audio content"),s.Nb(),s.Nb(),s.Nb(),s.Nb(),s.Nb(),s.Nb(),s.Nb()),2&t&&(s.fc("formGroup",e.editAudioContentForm),s.xb(8),s.fc("parentForm",e.editAudioContentForm)("isAudio",!0))},directives:[l.v,l.o,l.h,f.a],styles:[""]}),t}(),canActivate:[p.a]},{path:":categoryId/:playlistId",component:c},{path:"",component:b,canActivate:[p.a]}],y=o("usx+"),C=o("ecX2"),g=o("lDzL"),v=o("q8Lv");o.d(e,"AudioContentModule",(function(){return A}));var A=function(){function t(){}return t.\u0275mod=s.Hb({type:t}),t.\u0275inj=s.Gb({factory:function(e){return new(e||t)},imports:[[i.c,n.f.forChild(h),l.s.withConfig({warnOnNgModelWithFormControl:"never"}),l.j,g.d,y.b.forRoot(),C.b,v.a]]}),t}()}}]);
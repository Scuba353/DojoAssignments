from django.conf.urls import url
from . import views

urlpatterns = [
	url(r'^$', views.index),
	url(r'^register$', views.registervalid),
	url(r'^login$', views.loginvalid),
	url(r'^success$', views.success),
]
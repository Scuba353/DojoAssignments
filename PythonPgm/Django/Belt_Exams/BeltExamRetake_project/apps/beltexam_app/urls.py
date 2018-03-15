from django.conf.urls import url
from . import views

urlpatterns = [
	url(r'success$', views.success),
	url(r'createpoke/(?P<id>\d+)$', views.poke),


]
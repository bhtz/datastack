FROM mcr.microsoft.com/dotnet/core/sdk:3.1-focal

RUN apt-get update \
    && apt-get -y upgrade \
    && apt-get -y install python3 python3-pip python3-dev ipython3 nano

# RUN apt-get -y install julia

RUN apt-get -y install nmap 

RUN pip3 install jupyterlab

RUN apt-get -y install nodejs \
    && pip3 install --upgrade jupyterlab-git \
    && jupyter lab build --dev-build=False --minimize=False

RUN apt-get install -y graphviz libgraphviz-dev pkg-config

RUN pip3 install pandas xlrd matplotlib sqlalchemy psycopg2-binary pygraphviz eralchemy torch torchvision

ARG NB_USER="jupyter"
ARG NB_UID="1000"
ARG NB_GID="100"

RUN useradd -m -s /bin/bash -N -u $NB_UID $NB_USER

USER $NB_USER

ENV HOME=/home/$NB_USER

WORKDIR $HOME

ENV PATH="${PATH}:$HOME/.dotnet/tools/"

RUN dotnet tool install -g --add-source "https://dotnet.myget.org/F/dotnet-try/api/v3/index.json" dotnet-interactive

RUN dotnet-interactive jupyter install

# RUN julia -e 'using Pkg; pkg"add IJulia; add Plots; add CSV; add DataFrames"'

# RUN jupyter labextension install jupyterlab-spreadsheet

RUN jupyter kernelspec list

RUN mkdir $HOME/.jupyter
COPY ./jupyter_notebook_config.py $HOME/.jupyter/jupyter_notebook_config.py

RUN mkdir $HOME/work

USER root

RUN apt-get install sudo \
    && usermod -aG sudo $NB_USER

# prevent git init on this level
RUN mkdir $HOME/work/.git
COPY start.sh /start.sh
RUN chmod +x /start.sh
USER $NB_USER

CMD ["/start.sh"]
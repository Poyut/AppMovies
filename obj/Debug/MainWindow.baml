   M S B A M L   `   `   `  ����D  @AppMovies, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AppMovies	AppMovies  5   	       AppMovies.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:AppMovies     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65   .��5	      � ��5
   
   �� 5       �� ImageSource$ cinema_background.jpg��6   .+�5   
   �� -   5         ��Name$ 	searchBtn��5      $��Search��6$   $
��Left=�65   $��
319,10,0,0q�6P   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5         ��Name$ 	searchTxt��5      $
��Left=�6%   $��23��6@   $��	10,10,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $��Movie title...��6s   $	��Top=�6�   $	��179��6�   6�   �� 5   
   -   5         ��Name$ moviePoster��5      $
��Left=�6%   $	��371��6@   $��	10,38,0,0q�6M   $	��Top=�6`   $	��279��6x   �� 5   
   -   5        $ titleTxt��5      $
��Left=�6$   $��23��6?   $��
419,80,0,0q�6K   $
 Wrap=�6_   $��TextBox��6s   $	��Top=�6�   $	��363��6�   �� 5   
   -   5        $ releasedTxt��5      $
��Left=�6'   $��23��6B   $��419,108,0,0q�6N   $
 Wrap=�6c   $��TextBox��6w   $	��Top=�6�   $	��363��6�   �� 5   
   -   5        $ directorTxt��5      $
��Left=�6'   $��23��6B   $��419,136,0,0q�6N   $
 Wrap=�6c   $��TextBox��6w   $	��Top=�6�   $	��363��6�   �� 5   
   -   5        $ 	awardsTxt��5      $
��Left=�6%   $��59��6@   $��419,164,0,0q�6L   $
 Wrap=�6a   $��TextBox��6u   $	��Top=�6�   $	��363��6�   �� 5   
   -	   5        $ metascoreTxt��5      $
��Left=�6(   $��23��6C   $��419,228,0,0q�6O   $
 Wrap=�6d   $��TextBox��6x   $	��Top=�6�   $	��363��6�   �� 5   
   -
   5        $ boxOfficeTxt��5      $
��Left=�6(   $��23��6C   $��419,256,0,0q�6O   $
 Wrap=�6d   $��TextBox��6x   $	��Top=�6�   $	��363��6�   �� 5   
   $��Title��6   $
��Left=�6    $��
374,80,0,0q�6;   $	��Top=�6O   
���   ���6z   Z� �� 5   
   $��Realesed data��6   $
��Left=�6(   $��323,111,0,0q�6C   $	��Top=�6X   �� 5   
   $��Director��6   $
��Left=�6#   $��353,136,0,0q�6>   $	��Top=�6S   �� 5   
   $��Awards��6   $
��Left=�6!   $��357,167,0,0q�6<   $	��Top=�6Q   �� 5   
   $��	Metascore��6   $
��Left=�6$   $��341,228,0,0q�6?   $	��Top=�6T   �� 5   
   $��Domestic Box Office��6   $
��Left=�6.   $��289,259,0,0q�6I   $	��Top=�6^   �� 5   
   -   5        $ 
searchYear��5      $
��Left=�6&   $��23��6A   $��
194,10,0,0q�6M   $
 Wrap=�6a   $��Movie year...��6u   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -   5        $ addToListBtn��5      $��Add to my list��6'   $
��Left=�6@   $��692,389,0,0q�6[   $	��Top=�6p   $��90��6�   6�   �� 5   
   -   5        $ rateTxt��5      $
��Left=�6#   $��23��6>   $��419,386,0,0q�6J   $
 Wrap=�6_   $��0��6s   $	��Top=�6|   $��48��6�   �� 5   
   -   5        $ apreciationTxt��5      $
��Left=�6*   $��73��6E   $��419,308,0,0q�6Q   $
 Wrap=�6f   $��My apreciation��6z   $	��Top=�6�   $	��363��6�   �� 5    
   -   5        $ 	imdbIDTxt��5       $
��Left=�6%   $��23��6@   $��-159,214,0,0q�6L   $
 Wrap=�6b   $��TextBox��6v   $	��Top=�6�   $	��120��6�   5"      5#      